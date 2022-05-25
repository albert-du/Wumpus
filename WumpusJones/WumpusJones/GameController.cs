using System;

namespace WumpusJones
{
    public class GameController
    {
        private readonly string _name;
        private readonly GameLocation _gameLocation;
        private readonly Player _player;
        private readonly Action<string, Action<bool>> _trivia;
        private int _startingRoom;

        public Cave Cave { get; }

        public GameController(string name, int caveNumber, Action<string, Action<bool>> trivia)
        {
            Cave = new(caveNumber);
            _gameLocation = new(Cave);
            _player = new();
            _name = name;
            _trivia = trivia;
            _startingRoom = _gameLocation.PlayerRoom;
        }
        public void Move(int room)
        {
            var output = _gameLocation.MovePlayer(room);
            _player.Turns++;
            _player.Coins++;
            
            // TODO: get a piece of trivia and output with the warnings
            TextChanged(output);
            OnMove(this, new PlayerMoveEventArgs());

            // a minor amount of callback hell to wait for user input
            Action callback1 = () =>
            {
                if (room != _gameLocation.HoleRoom)
                {
                    // callback2
                    return;
                }
                if (_player.Coins-- < 0)
                {
                    GameEnded(false, "You die in a bottomless pit");
                    return;
                }
                _trivia("You're falling into a bottomless pit!", success => {
                    if (!success)
                    {
                        GameEnded(false, "You die in the bottomless pit.");
                        return;
                    }
                    _gameLocation.MovePlayer(_startingRoom);
                    TextChanged("You climb out of the bottomless pit");
                    OnMove(this, new PlayerMoveEventArgs());
                });
            };

            if (room != _gameLocation.WumpusRoom)
            {
                callback1();
                return;
            }
            if (_player.Coins-- < 0)
            {
                GameEnded(false, "The Boulder Crushes you.");
                return;
            }
            _trivia("You have encountered the boulder!", success =>
            {
                if (!success)
                {
                    GameEnded(false, "The Boulder Crushes you.");
                    return;
                }
                _gameLocation.RandomizeWumpus();
                TextChanged("The boulder rolls away");
                callback1();
            });
        }

        public void Shoot(int room)
        {
            if (room == _gameLocation.WumpusRoom)
                GameEnded(true, "You've destroyed the Boulder");
            else if (_player.ShootArrows())
                GameEnded(false, "The Boulder senses your weakness and crushes you.");
        }

        public void BuyArrows()
        {
            if (_player.Coins > 0)
            {
                _player.Coins--;
                _trivia("Buy an arrow.", _ => _player.ArrowPurchase());
            }
        }

        public event EventHandler<TextChangeEventArgs> OnTextChanged;
        public event EventHandler<GameEndEventArgs> OnGameEnd;
        public event EventHandler<PlayerMoveEventArgs> OnMove;
        
        private void TextChanged(string text) =>
            OnTextChanged(this, new TextChangeEventArgs { Text = text });
        private void GameEnded(bool won, string message) =>
            OnGameEnd(this, new GameEndEventArgs { Won = won, Message = message });
    }
}

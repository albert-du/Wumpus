#nullable enable

using System;

namespace WumpusJones
{
    public class GameController
    {
        private readonly Action<string, TriviaType, Action<bool>> _trivia;
        private readonly string _name;
        private readonly Trivia _triviaSource;
        public Cave Cave { get; }
        public Player Player { get; }
        public GameLocation GameLocation { get; }
        public Room PlayerLocation => Cave.RoomAt(GameLocation.PlayerRoom);

        public GameController(string name, int caveNumber, Action<string, TriviaType, Action<bool>> trivia, Trivia triviaSource)
        {
            Player = new();
            Cave = new(caveNumber);
            GameLocation = new(Cave);
            _name = name;
            _trivia = trivia;
            _triviaSource = triviaSource;
        }

        public void Move(int room)
        {
            Player.Turns++;
            Player.IncrementCoin();
            TextChanged(_triviaSource.GetRandomTrivia(), false);
            TextChanged(GameLocation.MovePlayer(room));
            OnMove?.Invoke(this, new PlayerMoveEventArgs());

            // I wouldn't touch this.
            void callback1()
            {
                if (room != GameLocation.HoleRoom)
                {
                    if (room != GameLocation.BatRoom1 && room != GameLocation.BatRoom2)
                        return;
                    // Check for snakes
                    if (Player.Coins-- < 1)
                    {
                        GameEnded(false, "The snakes kill you");
                        return;
                    }
                    _trivia("The snakes are carrying you away", TriviaType.Snakes, success =>
                    {
                        if (!success)
                        {
                            GameEnded(false, "The snakes kill you");
                            return;
                        }
                        GameLocation.RandomizePlayer();
                        TextChanged("The snakes leave you in a new location");
                        OnMove?.Invoke(this, new PlayerMoveEventArgs());
                    });
                    return;
                }
                if (Player.Coins-- < 1)
                {
                    GameEnded(false, "You die in a bottomless pit");
                    return;
                }
                _trivia("You're falling into a bottomless pit!", TriviaType.Pit, success =>
                {
                    if (!success)
                    {
                        GameEnded(false, "You die in the bottomless pit.");
                        return;
                    }
                    GameLocation.MovePlayer(GameLocation.StartingRoom);
                    TextChanged("You climb out of the bottomless pit");
                    OnMove?.Invoke(this, new PlayerMoveEventArgs());
                });
            }

            if (room != GameLocation.WumpusRoom)
            {
                callback1();
                return;
            }
            if (Player.Coins-- < 1)
            {
                GameEnded(false, "The Boulder Crushes you.");
                return;
            }
            _trivia("You have encountered the boulder!", TriviaType.Boulder, success =>
            {
                if (!success)
                {
                    GameEnded(false, "The Boulder Crushes you.");
                    return;
                }
                GameLocation.RandomizeWumpus();
                TextChanged("The boulder rolls away");
                callback1();
            });
            Player.IncrementCoin();
        }

        public void Shoot(int room)
        {
            if (room == GameLocation.WumpusRoom)
                GameEnded(true, "You've destroyed the Boulder");
            else if (!Player.ShootArrows())
                GameEnded(false, "The Boulder senses your weakness and crushes you.");
            else
                TextChanged($"Nothing hit in {room}", false);
        }

        public void BuyArrows()
        {
            if (Player.Coins > 0)
            {
                Player.Coins--;
                _trivia("Buy an arrow.", TriviaType.Arrows, x => { if (x) Player.ArrowPurchase(); });
            }
        }

        public event EventHandler<TextChangeEventArgs>? OnTextChanged;

        public event EventHandler<GameEndEventArgs>? OnGameEnd;

        public event EventHandler<PlayerMoveEventArgs>? OnMove;

        private void TextChanged(string text, bool includeRoomNum = true) =>
            OnTextChanged?.Invoke(this, new TextChangeEventArgs { Text = text, IncludeRoom = includeRoomNum });

        private void GameEnded(bool won, string message) =>
            OnGameEnd?.Invoke(this, new GameEndEventArgs { Won = won, Message = message });
    }
}
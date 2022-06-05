#nullable enable

using System;

namespace WumpusJones
{
    public class GameController
    {
        private readonly Action<string, TriviaType, Action<bool>> _trivia;
        private readonly string _name;
        private readonly bool _activeWumpus;
        private readonly Trivia _triviaSource;
        private readonly Random rnd = new();
        private readonly Wumpus wumpus;
        public Cave Cave { get; }
        public Player Player { get; }
        public GameLocation GameLocation { get; }
        public Highscores Highscores { get; } = new();
        public Room PlayerLocation => Cave.RoomAt(GameLocation.PlayerRoom);
        public PlayerScore GetScore(bool won) => new(_name, Player.Turns, Player.Coins, Player.Arrows, won, _activeWumpus);

        public GameController(string name, int caveNumber, Action<string, TriviaType, Action<bool>> trivia, Trivia triviaSource, bool activeWumpus)
        {
            Player = new();
            Cave = new(caveNumber);
            GameLocation = new(Cave);
            wumpus = activeWumpus ?  new ActiveWumpus(Cave) : new Wumpus(Cave);
            wumpus.Room = rnd.Next(1, 31);
            _name = name;
            _activeWumpus = activeWumpus;
            _trivia = trivia;
            _triviaSource = triviaSource;
        }

        public void Move(int room)
        {
            Player.Turn();
            TextChanged(_triviaSource.GetRandomTrivia(), false);
            TextChanged(GameLocation.MovePlayer(room));
            MoveImpl(room);
            Player.IncrementCoin();
            StatsChanged();
        }

        private void MoveImpl(int room)
        {
            // I wouldn't touch this.
            void callback1()
            {
                if (room != GameLocation.HoleRoom)
                {
                    var b1 = room == GameLocation.BatRoom1;
                    if (b1 || room == GameLocation.BatRoom2)
                    {
                        if (b1)
                            GameLocation.RandomizeBat1();
                        else
                            GameLocation.RandomizeBat2();
                        GameLocation.RandomizePlayer();
                        TextChanged("The snakes leave you in a new location");
                        TextChanged(GameLocation.MovePlayer(GameLocation.PlayerRoom));
                        PlayerMove(true);
                    }
                    else 
                        PlayerMove();
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
                    TextChanged("You climb out of the bottomless pit");
                    TextChanged(GameLocation.MovePlayer(GameLocation.StartingRoom));
                    PlayerMove();
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
                wumpus.TriviaLost();
                TextChanged("The boulder rolls away");
                PlayerMove();
                callback1();
            });
        }

        public void Shoot(int room)
        {
            if (room == GameLocation.WumpusRoom)
                GameEnded(true, "You've destroyed the Boulder");
            else if (!Player.ShootArrows())
                GameEnded(false, "The Boulder senses your weakness and crushes you.");
            else
            {
                TextChanged($"Nothing hit in {room}", false);
                if (rnd.Next(0, 2) == 0)
                {
                    wumpus.ArrowMissed();
                    TextChanged(GameLocation.MovePlayer(GameLocation.PlayerRoom));
                }
            }
            Player.Turn();
            StatsChanged();
        }

        public void BuyArrows()
        {
            if (Player.Coins > 0)
            {
                Player.Coins--;
                _trivia("Buy an arrow.", TriviaType.Arrows, x => 
                {
                    if (x) Player.ArrowPurchase();
                    Player.Turn();
                    StatsChanged(); 
                });
            }
        }

        private string GetSecret() => rnd.Next(6) switch
        {
            0 => $"Snakes at {(rnd.Next(2) == 0 ? GameLocation.BatRoom1 : GameLocation.BatRoom2)}",
            1 => $"Pit at {GameLocation.HoleRoom}",
            2 => $"Boulder at {GameLocation.WumpusRoom}",
            3 => $"Boulder is {(GameLocation.IsWumpusNearby ? string.Empty : "not")} nearby",
            4 => $"You're at {GameLocation.PlayerRoom}",
            _ => $"{_triviaSource.GetAlreadyAskedQuestion()}"
        };

        public void BuySecret()
        {
            if (Player.Coins > 0)
            {
                Player.Coins--;
                _trivia("Buying a secret", TriviaType.Secret, success =>
                {
                    TextChanged(success ? $"SECRET: {GetSecret()}" : "No secret", false);
                    if (success) Player.SecretPurchase();
                    Player.Turn();
                    StatsChanged();
                });
            }
        }

        public event EventHandler<TextChangeEventArgs>? OnTextChanged;

        public event EventHandler<GameEndEventArgs>? OnGameEnd;

        public event EventHandler<PlayerMoveEventArgs>? OnMove;
        public event EventHandler? OnStatsChanged;

        private void TextChanged(string text, bool includeRoomNum = true) =>
            OnTextChanged?.Invoke(this, new TextChangeEventArgs { Text = text, IncludeRoom = includeRoomNum });

        private void PlayerMove(bool snakes = false)
        {
            wumpus.WumpusTurn();
            GameLocation.WumpusRoom = wumpus.Room;
            OnMove?.Invoke(this, new PlayerMoveEventArgs { Snakes = snakes });
            if (wumpus.Room == GameLocation.PlayerRoom)
                MoveImpl(wumpus.Room);
            StatsChanged();
        }


        private void GameEnded(bool won, string message)
        {
            Highscores.Add(GetScore(won));
            OnGameEnd?.Invoke(this, new GameEndEventArgs { Won = won, Message = message });
        }
    
        private void StatsChanged() =>
            OnStatsChanged?.Invoke(this, new EventArgs());
    }
}
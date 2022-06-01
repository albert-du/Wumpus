namespace WumpusJones
{
    public class PlayerScore
    {
        public string Name { get; }
        public int Turns { get; }
        public int Coins { get; }
        public int Arrows { get; }
        public bool WumpusKilled { get; }
        public int Score =>
            100 - Turns + Coins + (5 * Arrows) + (WumpusKilled ? 50 : 0);

        public PlayerScore(string name, int turns, int coins, int arrows, bool wumpusKilled)
        {
            Name = name;
            Turns = turns;
            Coins = coins;
            Arrows = arrows;
            WumpusKilled = wumpusKilled;
        }
    }
}

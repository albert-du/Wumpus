using System;

namespace WumpusJones
{
    public record PlayerScore(string Name, int Turns, int Coins, int Arrows, bool WumpusKilled)
    {
        public DateTime Time { get; private init; } = DateTime.UtcNow;
        public int Score =>
            100 - Turns + Coins + (5 * Arrows) + (WumpusKilled ? 50 : 0);
    }
}

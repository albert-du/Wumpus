using System.Collections.Generic;

namespace WumpusJones
{
    public interface IHighScores
    {
        void AddScore(string name, int score);
        void AddScore(PlayerScore score);
        IReadOnlyList<PlayerScore> Scores { get; }
    }
}
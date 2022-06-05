using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace WumpusJones
{
    public class Highscores
    {
        private readonly string path = "./WumpusScores.txt";
        public IEnumerable<PlayerScore> TopScores { get; private set; }

        public void Add(PlayerScore score)
        {
            TopScores = TopScores.Where(x => x.Name != score.Name).Append(score).OrderByDescending(x => x.Score).Take(10);
            File.WriteAllLines(path, TopScores.Select(x => JsonSerializer.Serialize(x)));
        }

        public Highscores()
        {
            var defaults = false;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                defaults = true;
            }
            TopScores = 
                File.ReadAllLines(path)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => JsonSerializer.Deserialize<PlayerScore>(x));
            if (defaults)
            {
                var defaultScores = new[] { 
                    new PlayerScore("Albert", 100, 0, 0, false, false),
                    new PlayerScore("Alex", 100, 0, 0, false, false),
                    new PlayerScore("Joshua", 100, 0, 0, false, false),
                    new PlayerScore("Marcus", 100, 0, 0, false, false),
                    new PlayerScore("Matthew", 100, 0, 0, false, false),
                    new PlayerScore("Ralph", 100, 0, 0, false, false)
                };
                foreach (var score in defaultScores)
                    Add(score);
            }
        }
    }
}

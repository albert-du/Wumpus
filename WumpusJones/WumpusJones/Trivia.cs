using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WumpusJones
{
    public class Trivia
    {
        private int ptr;
        private readonly Random rnd;

        private readonly List<Question> questions;

        public Trivia(Random random)
        {
            rnd = random;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(x => x.EndsWith("trivia.txt"));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            questions = reader.ReadToEnd()
                              .Split('\n')
                              .Select(x => new Question(x.Split(';')))
                              .OrderBy(_ => rnd.Next())
                              .ToList();
        }

        public Question GetQuestion()
        {
            return questions[ptr++ % questions.Count];
        }

        public string GetAlreadyAskedQuestion()
        {
            var q = questions[rnd.Next(Math.Min(ptr, questions.Count))];
            return $"{q.Text} | \"{q.Answers[0]}\"";
        }

        public string GetRandomTrivia()
        {
            var q = questions[rnd.Next(questions.Count)];
            return $"Trivia: {q.Text} | \"{q.Answers[0]}\"";
        }
    }
}
using System;
using System.Linq;

namespace WumpusJones
{
    public class Trivia
    {
        private int ptr;
        private readonly Random rnd = new();

        private readonly Question[] questions =
        {
            new Question("Who is indiana jones?", "right", "wrong1", "wrong2" , "wrong3"),
            new Question("Who is indiana jones?1", "right", "wrong1", "wrong2" , "wrong3"),
        };

        public Trivia() =>
            questions.OrderBy(_ => rnd.Next());

        public Question GetQuestion()
        {
            return questions[ptr++ % questions.Length];
        }

        public string GetAlreadyAskedQuestion()
        {
            var q = questions[rnd.Next(Math.Min(ptr, questions.Length))];
            return $"{q.Text} | \"{q.Answers[0]}\"";
        }

        public string GetRandomTrivia()
        {
            var q = questions[rnd.Next(questions.Length)];
            return $"Trivia: {q.Text} | \"{q.Answers[0]}\"";
        }
    }
}
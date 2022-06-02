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
            new Question("What is Indiana Jones afraid of?", "snakes", "dogs", "planes", "himself"),
            new Question("Who plays Indiana Jones in the original three movies?", "Harrison Ford", "Dwayne Johnson", "Kevin Hart", "Tom Holand"),
            new Question("What kind of dog does Indiana Jones have as a kid?", "Huskey", "Shiba Inu", "Golden retriever", "He didn't have a dog"),
            new Question("In Temple of Doom, how many Shankara stones fall to the bottom the the ravine?", "2", "1", "3", "4"),
            new Question("In which Indiana Jones movie does someone try to kill him?", "Raiders of the lost ark", "Indiana Jones and The Last Crusade", "Indiana Jones and The Temple of Doom", "All of them"),
            new Question("What is Indiana Jones' trademark weapon?", "A bullwhip", "a sword", "a machine gun", "a laser"),
            new Question("When did the first Indiana Jones movie come out?", "1989", "1999", "2005", "1985"),
            new Question("What color is Indiana Jones' hat?", "brown", "red", "black", "white"),
            new Question("Where does Indiana Jones teach archaeology?", "Marshall college", "Norwalk College", "Trinity College", "Goodwin College"),
            new Question("What is the name of the cult in Indiana Jones and the Temple of Doom?", "The people's Temple", "Thuggers", "Raelians", "Heaven's Gate")
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
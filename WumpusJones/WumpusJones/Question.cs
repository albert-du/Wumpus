namespace WumpusJones
{
    public class Question
    {
        public string Text { get; }
        public string[] Answers { get; }
        public Question(string question, string answer1, string answer2, string answer3, string answer4)
        {
            Text = question;
            Answers = new[] { answer1, answer2, answer3, answer4 };
        }
    }
}
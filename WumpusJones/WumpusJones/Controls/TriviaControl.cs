using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class TriviaControl : UserControl
    {
        public Trivia Trivia { get; set; }
        private readonly Random _rnd = new();
        private string _correctAnswer;
        private int _questionCount;
        private int _correctlyAnswered;
        private int _incorrectlyAnswered;

        public TriviaControl()
        {
            InitializeComponent();
            Hide();
        }

        public void Init(string title, int questionCount)
        {
            _questionCount = questionCount;
            _correctlyAnswered = 0;
            _incorrectlyAnswered = 0;
            labelTitle.Text = title;
            LoadQuestion();
            Show();
        }

        public event EventHandler<TriviaFinishedEventArgs> TriviaFinished;

        private void LoadQuestion()
        {
            var question = Trivia.GetQuestion();
            _correctAnswer = question.Answers[0];
            var shuffled = question.Answers.OrderBy(_ => _rnd.Next()).ToArray();
            buttonA.Text = shuffled[0];
            buttonB.Text = shuffled[1];
            buttonC.Text = shuffled[2];
            buttonD.Text = shuffled[3];
        }

        private void CheckAnswer(string answer)
        {
            if (answer == _correctAnswer)
                _correctlyAnswered++;
            else
                _incorrectlyAnswered++;

            if (_correctlyAnswered + _incorrectlyAnswered < _questionCount)
                LoadQuestion();
            else
            {
                Hide();
                TriviaFinished.Invoke(this, new TriviaFinishedEventArgs { Correct = _correctlyAnswered, Incorrect = _incorrectlyAnswered });
            }
        }

        private void buttonA_Click(object sender, EventArgs e) =>
            CheckAnswer(buttonA.Text);

        private void buttonB_Click(object sender, EventArgs e) =>
            CheckAnswer(buttonB.Text);

        private void buttonC_Click(object sender, EventArgs e) =>
            CheckAnswer(buttonC.Text);

        private void buttonD_Click(object sender, EventArgs e) =>
            CheckAnswer(buttonD.Text);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class TriviaControl : UserControl
    {
        private readonly Random _rnd = new();
        private string _correctAnswer;
        private int _questionCount;
        readonly List<bool> results = new();

        public Trivia Trivia { get; set; }
        public TriviaControl()
        {
            InitializeComponent();
            Hide();
        }

        public void Init(string title, int questionCount)
        {
            _questionCount = questionCount;
            results.Clear();
            labelTitle.Text = title;
            labelCompletion.Text = string.Join(" ", Enumerable.Repeat("[ ]", questionCount));
            LoadQuestion();
            Show();
        }

        public event EventHandler<TriviaFinishedEventArgs> TriviaFinished;

        private void LoadQuestion()
        {
            var question = Trivia.GetQuestion();
            labelQuestion.Text = question.Text;
            _correctAnswer = question.Answers[0];
            var shuffled = question.Answers.OrderBy(_ => _rnd.Next()).ToArray();
            buttonA.Text = shuffled[0];
            buttonB.Text = shuffled[1];
            buttonC.Text = shuffled[2];
            buttonD.Text = shuffled[3];
            buttonA.BackColor = SystemColors.Control;
            buttonB.BackColor = SystemColors.Control;
            buttonC.BackColor = SystemColors.Control;
            buttonD.BackColor = SystemColors.Control;
        }

        private bool CheckAnswer(string answer)
        {
            buttonNext.Enabled = true;
            var c = answer == _correctAnswer;
            if (c)
                results.Add(true);
            else
                results.Add(false);


            var r = results.Select(x => x ? "[✅]" : "[❎]")
                           .Concat(Enumerable.Repeat("[ ]", _questionCount - results.Count));

            labelCompletion.Text = string.Join(" ", r);

            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;

            return c;
        }

        private void buttonA_Click(object sender, EventArgs e) =>
            buttonA.BackColor = CheckAnswer(buttonA.Text) ? Color.Green : Color.Red;

        private void buttonB_Click(object sender, EventArgs e) =>
            buttonB.BackColor = CheckAnswer(buttonB.Text) ? Color.Green : Color.Red;

        private void buttonC_Click(object sender, EventArgs e) =>
            buttonC.BackColor = CheckAnswer(buttonC.Text) ? Color.Green : Color.Red;

        private void buttonD_Click(object sender, EventArgs e) =>
            buttonD.BackColor = CheckAnswer(buttonD.Text) ? Color.Green : Color.Red;

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;

            buttonNext.Enabled = false;
            if (results.Count < _questionCount)
                LoadQuestion();
            else
            {
                Hide();
                TriviaFinished.Invoke(this, new TriviaFinishedEventArgs { Correct = results.Where(x => x).Count(), Incorrect = results.Where(x => !x).Count() });
            }
        }
    }
}

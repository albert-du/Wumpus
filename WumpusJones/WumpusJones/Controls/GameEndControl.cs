using System;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class GameEndControl : UserControl
    {
        public GameEndControl()
        {
            InitializeComponent();
        }

        public string Title { set => labelTitle.Text = value; }
        public string Message { set => richTextBox1.Text = value; }
        public Highscores Highscores { get; set; }

        private void buttonReplay_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            HighscoreForm highscoreForm = new () { HighScores = Highscores };
            highscoreForm.ShowDialog();
        }
    }
}
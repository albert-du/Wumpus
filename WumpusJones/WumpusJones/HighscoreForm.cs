using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class HighscoreForm : Form
    {
        public Highscores HighScores { get; init; }
        public HighscoreForm() =>
            InitializeComponent();

        private void Form1_Load(object sender, EventArgs e) =>
            listBox1.Items.AddRange(HighScores.TopScores.Select(x => $"{x.Name}\t\t{x.Score}\t{(x.ActiveWumpus ? "A" : "L")}").ToArray());

        private void buttonClose_Click(object sender, EventArgs e) =>
            Close();
    }
}

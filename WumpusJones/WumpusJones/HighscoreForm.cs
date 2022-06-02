using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class HighscoreForm : Form
    {
        public Highscores HighScores { get; set; }
        public HighscoreForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(HighScores.TopScores.Select(x => $"{x.Name}\t\t{x.Score}").ToArray());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

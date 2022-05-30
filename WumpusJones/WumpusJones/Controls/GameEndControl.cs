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

        private void buttonReplay_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
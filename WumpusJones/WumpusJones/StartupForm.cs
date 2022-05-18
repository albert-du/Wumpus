using System;
using System.Windows.Forms;

namespace WumpusJones
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            label1.Font = Program.CustomFont;
        }

        public string PlayerName { get; private set; }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Enter a name.");
                return;
            }
            PlayerName = textBoxName.Text;
        }
    }
}

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
            Close();
        }

        private void StartupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the startup is closed without a name, just close the entire application.
            if (PlayerName is null) Application.Exit();
        }
    }
}

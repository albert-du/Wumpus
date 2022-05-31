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
        private Dictionary<string, int> scoresDictionary = new Dictionary<string, int>();
        public HighscoreForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scoresDictionary.Add("Albert", 0);
            scoresDictionary.Add("Alex", 0);
            scoresDictionary.Add("Joshua", 0);
            scoresDictionary.Add("Marcus", 0);
            scoresDictionary.Add("Matthew", 0);
            scoresDictionary.Add("Ralph", 0);
            listBox1.Items.Add("Albert" + "     " + 0);
            listBox1.Items.Add("Alex" + "     " + 0);
            listBox1.Items.Add("Joshua" + "     " + 0);
            listBox1.Items.Add("Marcus" + "     " + 0);
            listBox1.Items.Add("Matthew" + "     " + 0);
            listBox1.Items.Add("Ralph" + "     " + 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //was going to be a list to sort it out, then an array, but a dictionary
            //allows you to have strings and arrays
            try
            {
                string name = textBox1.Text;
                int coins = Convert.ToInt32(textBox2.Text);
                scoresDictionary.Add(name, coins);
                //adds coins and the name to the dictionary as a new entry
                string[] keys = scoresDictionary.Keys.ToArray();
                //creates an array for the names
                int[] values = scoresDictionary.Values.ToArray();
                //creates an array for the coins
                for (int i = 0; i < keys.Count(); i++)
                {
                    for (int j = 0; j < keys.Count() - 1; j++)
                    {
                        string entryName = keys[j];
                        int entryScore = values[j];
                        //makes it look nicer rather than values[j] < values[j + 1]
                        if (entryScore < values[j + 1])
                        {
                            int temp = entryScore;
                            //temp int to store the values while everything gets moved
                            values[j] = values[j + 1];
                            //getting moved
                            values[j + 1] = temp;
                            //saved as temp and repeated to move down

                            keys[j] = keys[j + 1];
                            keys[j + 1] = entryName;
                        }
                    }
                }
                listBox1.Items.Clear();
                //clears everything for a clean slate to print out the dictionary
                for (int i = 0; i < keys.Count(); i++)
                {
                    listBox1.Items.Add(keys[i] + "     " + values[i]);
                    //adds first the names ^ then coins ^
                }
            }
            catch
            {
                MessageBox.Show("You inputted the same number twice!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

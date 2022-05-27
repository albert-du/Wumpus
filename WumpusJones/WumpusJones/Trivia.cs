using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1081979_Cifu_WumpusTrivia1
{
    
    public partial class Form1 : Form
    {
        List<Questions> question = new List<Questions>();
        int coins = 5;
        int trys = 3;

        string[] questions = new string[]
            { "What is Indiana Jones afraid of?",
            "Who plays Indiana Jones in the original three movies?",
            "What kind of dog does Indiana Jones have as a kid?",
            "In Temple of Doom, how many Shankara stones fall to the bottom the the ravine?",
            "In which Indiana Jones movie does someone try to kill him?",
            "What is Indiana Jones' trademark weapon?",
            "When did the first Indiana Jones movie come out?",
            "What color is Indiana Jones' hat?",
            "Where does Indiana Jones teach archaeology?",
            "What is the name of the cult in Indiana Jones and the Temple of Doom?"};

        string[] answers = new string[] {
            "dogs, snakes, planes, himself",
            "harrison Ford, Dawayne Johnson, Kevin Heart, Tom Holand",
            "Shiba Inu, Golden retriever, Huskey, He didn't have a dog",
            "1 , 2, 3, 4",
            "Raiders of the lost ark, Indiana Jones and The Last Crusade, Indiana Jones and The Temple of Doom, All of them",
            "A bullwhip, a sword, a machine gun, a laser",
            "1999, 2005, 1985, 1989",
            "red, black, brown, white",
            "Marshall college, Norwalk College, Trinity College, Goodwin College",
            "The people's Temple, Thuggers, Raelians, Heaven's Gate"};
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int random = new Random().Next(10);
            labelTrivia.Text = questions[random];
            labelOptions.Text = answers[random];
            
            
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            if(labelTrivia.Text == questions[0])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
                

            }
            else if(labelTrivia.Text == questions[1])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[2])
            {
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                coins -= 1;
                labelCoins.Text = coins.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[3])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[4])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[5])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[6])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[7])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[8])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[9])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }


        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            if (labelTrivia.Text == questions[0])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[1])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[2])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[3])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[4])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[5])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[6])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[7])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[8])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[9])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (labelTrivia.Text == questions[0])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[1])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[2])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[3])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[4])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[5])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[6])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[7])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[8])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[9])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }

        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            if (labelTrivia.Text == questions[0])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[1])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[2])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[3])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[4])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[5])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[6])
            {
                coins += 1;
                labelCoins.Text = coins.ToString();
                trys = 3;
                labelAttempts.Text = trys.ToString();
                MessageBox.Show("Correct gain a coin");
                int random = new Random().Next(10);
                labelTrivia.Text = questions[random];
                labelOptions.Text = answers[random];
            }
            else if (labelTrivia.Text == questions[7])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[8])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
            else if (labelTrivia.Text == questions[9])
            {
                coins -= 1;
                labelCoins.Text = coins.ToString();
                trys -= 1;
                labelAttempts.Text = trys.ToString();
                if (trys == 0)
                {
                    MessageBox.Show("You Die");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong, lose a coin");
                }
            }
        }

        private void labelTrivia_Click(object sender, EventArgs e)
        {

        }
    }
}

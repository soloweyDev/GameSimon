using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GameSimon
{
    public partial class Form1 : Form
    {
        string[] arrey = new string[100];
        int round = 0;
        int checkround = 0;
        int sleep = 1000;
        Random random = new Random();
        Button button;
        Color color;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnNewGame.Enabled = false;
            round = 5;
            checkround = 0;
            GameLoop();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        void GameLoop()
        {
            lblRound.Text = "Round: " + (round + 1).ToString();
            for (int i = 0; i <= round; i++)
            {
                int temp = random.Next(0, 4);
                arrey[i] = ConvertColor(temp);
                button.BackColor = color;
                Refresh();
                Thread.Sleep(sleep);
                ConvertColor(temp + 5);
                button.BackColor = color;
                Refresh();
            }
            EnabledButtons();
        }

        void EnabledButtons()
        {
            btnRed.Enabled = true;
            btnGreen.Enabled = true;
            btnBlue.Enabled = true;
            btnYellow.Enabled = true;
        }

        void DisabledButtons()
        {
            btnRed.Enabled = false;
            btnGreen.Enabled = false;
            btnBlue.Enabled = false;
            btnYellow.Enabled = false;
        }

        string ConvertColor(int number)
        {
            switch (number)
            {
                case 0:
                    button = btnRed;
                    color = Color.Red;
                    return "Red";

                case 1:
                    button = btnGreen;
                    color = Color.Green;
                    return "Green";

                case 2:
                    button = btnBlue;
                    color = Color.Blue;
                    return "Blue";

                case 3:
                    button = btnYellow;
                    color = Color.Yellow;
                    return "Yellow";

                case 5:
                    button = btnRed;
                    color = Color.DarkRed;
                    return "DarkRed";

                case 6:
                    button = btnGreen;
                    color = Color.DarkGreen;
                    return "DarkGreen";

                case 7:
                    button = btnBlue;
                    color = Color.DarkBlue;
                    return "DarkBlue";

                case 8:
                    button = btnYellow;
                    color = Color.Gold;
                    return "Gold";

                default:
                    button = null;
                    color = Color.Empty;
                    return string.Empty;
            }
        }

        void Check(string tag)
        {
            if (checkround == round)
            {
                if (arrey[checkround] == tag)
                {
                    GameLoop();
                }
                else
                {
                    string text = "";
                    MessageBox.Show("Result the game", text);
                }
            }
        }
    }
}

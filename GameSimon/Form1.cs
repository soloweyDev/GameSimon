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
        string goodResult = null;

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
            round = 0;
            checkround = 0;
            GameLoop();
        }

        private void btnRed_MouseDown(object sender, MouseEventArgs e)
        {
            btnRed.BackColor = Color.Red;
        }

        private void btnGreen_MouseDown(object sender, MouseEventArgs e)
        {
            btnGreen.BackColor = Color.Lime;
        }

        private void btnBlue_MouseDown(object sender, MouseEventArgs e)
        {
            btnBlue.BackColor = Color.Blue;
        }

        private void btnYellow_MouseDown(object sender, MouseEventArgs e)
        {
            btnYellow.BackColor = Color.Yellow;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            btnRed.BackColor = Color.DarkRed;
            Refresh();
            Check(btnRed.Tag.ToString());
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            btnGreen.BackColor = Color.DarkGreen;
            Refresh();
            Check(btnGreen.Tag.ToString());
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            btnBlue.BackColor = Color.DarkBlue;
            Refresh();
            Check(btnBlue.Tag.ToString());
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            btnYellow.BackColor = Color.Gold;
            Refresh();
            Check(btnYellow.Tag.ToString());
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
                    color = Color.Lime;
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

        void GetGoodString()
        {
            goodResult = "";
            for (int i = 0; i <= round; ++i)
            {
                goodResult += arrey[i] + " ";
            }
        }

        void GameLoop()
        {
            Thread.Sleep(sleep);
            checkround = 0;
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
                Thread.Sleep(sleep);
            }
            EnabledButtons();
        }

        void Check(string tag)
        {
            if (checkround == round)
            {
                if (arrey[checkround] != tag)
                {
                    GameOver(checkround);
                    return;
                }

                GetGoodString();
                round++;
                GameLoop();
            }
            else
            {
                if (arrey[checkround] != tag)
                {
                    GameOver(checkround);
                    return;
                }

                checkround++;
            }
        }

        private void GameOver(int maxCheck)
        {
            btnNewGame.Enabled = true;
            DisabledButtons();
            string text = "Maximum sequence: " + goodResult.Trim();
            MessageBox.Show(text, "Result the game");
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GameSimon
{
    public partial class Form1 : Form
    {
        readonly string[] arrey = new string[100];  // 
        int score = 0;                              // 
        int checkround = 0;                         // 
        readonly int sleep = 1000;                  // 
        readonly Random random = new Random();
        Button button;                              // 
        Color color;                                // 

        public Form1()
        {
            InitializeComponent();
        }

        // Exit app
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Start new game
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnNewGame.Enabled = false;
            score = 0;
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

        void GameLoop()
        {
            Thread.Sleep(sleep);
            checkround = 0;
            lblRound.Text = "Round: " + (score + 1).ToString();
            for (int i = 0; i <= score; i++)
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
            if (checkround == score)
            {
                if (arrey[checkround] != tag)
                {
                    GameOver(score);
                    return;
                }

                score++;
                GameLoop();
            }
            else
            {
                if (arrey[checkround] != tag)
                {
                    GameOver(score);
                    return;
                }

                checkround++;
            }
        }

        private void GameOver(int maxCheck)
        {
            string text = "Maximum sequence: " + maxCheck;
            MessageBox.Show(text, "Result the game");

            if (!File.Exists("record.txt"))
            {
                Name nameForm = new Name();
                nameForm.ShowDialog(this);
                string name = nameForm.textBox.Text;

                using (StreamWriter sw = new StreamWriter("record.txt"))
                {
                    string newLine = string.Format("{0};{1}", maxCheck, name);
                    sw.WriteLine(newLine);
                }
            }
            else
            {
                string allLines = null;

                using (StreamReader sr = new StreamReader("record.txt"))
                {
                    string line1 = sr.ReadLine();
                    string[] arrey = line1.Split(';');
                    if (Convert.ToInt32(arrey[0]) < maxCheck)
                    {
                        Name nameForm = new Name();
                        nameForm.ShowDialog(this);
                        string name = nameForm.textBox.Text;

                        string newLine = string.Format("{0};{1}", maxCheck, name);
                        allLines = newLine + "\r\n" + line1 + "\r\n" + sr.ReadToEnd();
                    }
                }

                using (StreamWriter sw = new StreamWriter("record.txt", false))
                {
                    sw.WriteLine(allLines);
                }
            }

            ViewRecords();
            btnNewGame.Enabled = true;
            DisabledButtons();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            ViewRecords();
        }

        private static void ViewRecords()
        {
            using (StreamReader sr = new StreamReader("record.txt"))
            {
                string text = string.Format("{0:15}\t{1}", "Name", "Score");
                text += "\r\n";

                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] arrey = line.Split(';');

                        text += "\r\n";
                        text += string.Format("{0:15}\t{1}", arrey[1], arrey[0]);
                    }
                }
                MessageBox.Show(text, "Records the game");
            }
        }
    }
}

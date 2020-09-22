using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GameSimon
{
    public partial class Form1 : Form
    {
        readonly string[] arrey = new string[100];  // Array of color sequences
        int score = 0;                              // Score (number) of the game cycle
        int checkNumber = 0;                        // Repeated item number
        readonly int sleep = 1000;                  // The time we wait when showing a color
        readonly Random random = new Random();
        Button button;                              // The button that was pressed
        Color color;                                // The displayed color on the button we are using

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
            checkNumber = 0;
            GameLoop();
        }

        #region Methods for handling pressing the mouse button
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
        #endregion

        #region Methods for handling mouse button click
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

        private void btnRecords_Click(object sender, EventArgs e)
        {
            ViewRecords();
        }
        #endregion

        // Making buttons active for user clicks
        void EnabledButtons()
        {
            btnRed.Enabled = true;
            btnGreen.Enabled = true;
            btnBlue.Enabled = true;
            btnYellow.Enabled = true;
        }

        //Making buttons inactive for user clicks
        void DisabledButtons()
        {
            btnRed.Enabled = false;
            btnGreen.Enabled = false;
            btnBlue.Enabled = false;
            btnYellow.Enabled = false;
        }

        // Convert int to the color that will be used in the desired button
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

        // Game loop
        void GameLoop()
        {
            // Delay before starting work (slowdown)
            Thread.Sleep(sleep);
            checkNumber = 0;

            // Displaying the current round
            lblRound.Text = "Round: " + (score + 1).ToString();

            // Cycle showing a sequence of buttons
            for (int i = 0; i <= score; i++)
            {
                // Get the button color (0 - Red, 1 - Green, 2 - Blue, 3 - Yellow)
                int temp = random.Next(0, 4);
                arrey[i] = ConvertColor(temp);
                button.BackColor = color;
                // Redraw GUI
                Refresh();
                // We are waiting for the player to see the color
                Thread.Sleep(sleep);

                // Return to initial state
                ConvertColor(temp + 5);
                button.BackColor = color;
                Refresh();
                Thread.Sleep(sleep);
            }

            EnabledButtons();
        }

        // Player sequence check
        void Check(string tag)
        {
            // Is it the last action
            if (checkNumber == score)
            {
                // Checking for correspondence of the color in the array and the color of the button
                if (arrey[checkNumber] != tag)
                {
                    // The colors are not the same. End of the game. We exit the method.
                    GameOver(score);
                    return;
                }

                // Increase the counter score and start a new color sequence
                score++;
                DisabledButtons();
                GameLoop();
            }
            else
            {
                // Checking for correspondence of the color in the array and the color of the button
                if (arrey[checkNumber] != tag)
                {
                    // The colors are not the same. End of the game. We exit the method.
                    GameOver(score);
                    return;
                }

                // Increase the counter player click
                checkNumber++;
            }
        }

        // End of the game
        private void GameOver(int maxCheck)
        {
            // Tell the player their final score
            string text = "Maximum sequence: " + maxCheck;
            MessageBox.Show(text, "Result the game");

            // Check if the file with records exists
            if (!File.Exists("record.txt"))
            {
                // Create the new form for input the player's name
                Name nameForm = new Name();
                nameForm.ShowDialog(this);
                // Passing the player's name from the forms to the variable
                string name = nameForm.textBox.Text;

                // Saving to the record's file
                using (StreamWriter sw = new StreamWriter("record.txt"))
                {
                    string newLine = string.Format("{0};{1}", maxCheck, name != "" ? name : "noname");
                    sw.WriteLine(newLine);
                }
            }
            else
            {
                string allLines = null;

                using (StreamReader sr = new StreamReader("record.txt"))
                {
                    // The best results are at the beginning of the file. Therefore, we only read the first line.
                    string line1 = sr.ReadLine();
                    if (string.IsNullOrEmpty(line1))
                    {
                        // Create the new form for input the player's name
                        Name nameForm = new Name();
                        nameForm.ShowDialog(this);
                        // Passing the player's name from the forms to the variable
                        string name = nameForm.textBox.Text;

                        // Create a line the records
                        allLines = string.Format("{0};{1}", maxCheck, name != "" ? name : "noname");
                    }
                    else
                    {
                        // We get the array by separator. The first value is the maximum score, the second is the name.
                        string[] arrey = line1.Split(';');
                        // Checking whether the current result will be a new record
                        if (Convert.ToInt32(arrey[0]) < maxCheck)
                        {
                            // New record!! GOOD!!!

                            // Create the new form for input the player's name
                            Name nameForm = new Name();
                            nameForm.ShowDialog(this);
                            // Passing the player's name from the forms to the variable
                            string name = nameForm.textBox.Text;

                            // Create a line to which we add all the records
                            string newLine = string.Format("{0};{1}", maxCheck, name != "" ? name : "noname");
                            allLines = newLine + "\r\n" + line1 + "\r\n" + sr.ReadToEnd();
                        }
                    }
                }

                // Saving to the record's file
                using (StreamWriter sw = new StreamWriter("record.txt", false))
                {
                    sw.WriteLine(allLines);
                }
            }

            // Displaying a list of records
            ViewRecords();
            // Activate the new game button and deactivate the colored buttons
            btnNewGame.Enabled = true;
            DisabledButtons();
        }

        // Displaying a list of records
        private static void ViewRecords()
        {
            string text = string.Format("{0,-20}\t{1}", "Name", "Score");
            text += "\r\n";

            if (File.Exists("record.txt"))
            {
                using (StreamReader sr = new StreamReader("record.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] arrey = line.Split(';');

                            text += "\r\n";
                            text += string.Format("{0,-20}\t{1}", arrey[1], arrey[0]);
                        }
                    }
                }
            }

            MessageBox.Show(text, "Records the game");
        }
    }
}

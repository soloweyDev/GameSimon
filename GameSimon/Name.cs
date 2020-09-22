using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameSimon
{
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
        }

        // Occurs when the control is entered
        private void textBox_Enter(object sender, EventArgs e)
        {
            textBox.Text = null;
            textBox.ForeColor = Color.Black;
        }

        // Exit form
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

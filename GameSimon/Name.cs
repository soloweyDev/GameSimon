using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSimon
{
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            textBox.Text = null;
            textBox.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

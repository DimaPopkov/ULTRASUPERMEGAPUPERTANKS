using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Gray;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            label3.Text = "Стоимость: 1200000";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Gray;
            pictureBox4.BackColor = Color.Transparent;
            label3.Text = "Стоимость: 1400000";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Gray;
            label3.Text = "Стоимость: 1600000";
        }
    }
}

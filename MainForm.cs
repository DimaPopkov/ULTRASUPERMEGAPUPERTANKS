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
            tankPower.Add("Танк Гротте", 250);
            tankPower.Add("Армата", 1500);
            tankPower.Add("КВ-85", 600);
            tankPower.Add("Т-54Б", 520);
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

        Dictionary<string, int> tankPower = new Dictionary<string, int>();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tank = comboBox1.Text;

            try
            {
                label2.Text = "Мощность " + tankPower[tank] + " л.с.";
            }
            catch (Exception)
            {

            }

            try
            {
                pictureBox1.Load("../../Pictures/Tanks/" + tank + ".png");
            }
            catch (Exception)
            {
                try
                {
                    pictureBox1.Load("../../Pictures/Tanks/" + tank + ".jpg");
                }
                catch (Exception)
                {

                }
            }
        }
    }
}

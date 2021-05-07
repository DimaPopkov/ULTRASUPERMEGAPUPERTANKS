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
        Dictionary<string, Tank> tanks = new Dictionary<string, Tank>();

        public MainForm()
        {
            InitializeComponent();

            Tank tank1 = new Tank
            {
                Name = "Армата",
                Power = 1500,
                Price = 1200000,
                Picture = Image.FromFile("../../Pictures/Tanks/Armata.png")
            };
            Tank tank2 = new Tank
            {
                Name = "Т-54Б",
                Power = 100,
                Price = 100000,
                Picture = Image.FromFile("../../Pictures/Tanks/T-54B.png")
            };

            tanks.Add(tank1.Name, tank1);
            tanks.Add(tank2.Name, tank2);

            comboBox1.Items.Clear();
            foreach (var tank in tanks)
                comboBox1.Items.Add(tank.Key);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;

            Tank currentTank = tanks[comboBox1.Text];
            pictureBox1.Image = currentTank.Picture;
            label3.Text = "Стоимость: " + currentTank.Price.ToString() + " рублей";
            label2.Text = "Мощность: " + currentTank.Power.ToString() + " л.с.";
        }
    }
}

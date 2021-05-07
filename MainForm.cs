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
        /// <summary>
        /// Все танки
        /// </summary>
        readonly Dictionary<string, Tank> Tanks = new Dictionary<string, Tank>();

        public MainForm()
        {
            InitializeComponent();

            Tank tank1 = new Tank
            {
                Name = "Армата",
                Power = 1500,
                Price = 1200000,
                Picture = Image.FromFile("../../Pictures/Tanks/Армата.png")
            };
            Tank tank2 = new Tank
            {
                Name = "Т-54Б",
                Power = 520,
                Price = 100000,
                Picture = Image.FromFile("../../Pictures/Tanks/Т-54Б.png")
            };
            Tank tank3 = new Tank
            {
                Name = "Танк Гротте",
                Power = 250,
                Price = 100000,
                Picture = Image.FromFile("../../Pictures/Tanks/Танк Гротте.jpg")
            };
            Tank tank4 = new Tank
            {
                Name = "КВ-85",
                Power = 600,
                Price = 100000,
                Picture = Image.FromFile("../../Pictures/Tanks/КВ-85.jpg")
            };

            Tanks.Add(tank1.Name, tank1);
            Tanks.Add(tank2.Name, tank2);
            Tanks.Add(tank3.Name, tank3);
            Tanks.Add(tank4.Name, tank4);

            comboBox1.Items.Clear();
            foreach (var tank in Tanks)
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

            Tank currentTank = Tanks[comboBox1.Text];
            pictureBox1.Image = currentTank.Picture;
            label3.Text = "Стоимость: " + currentTank.Price.ToString() + " рублей";
            label2.Text = "Мощность: " + currentTank.Power.ToString() + " л.с.";
        }
    }
}

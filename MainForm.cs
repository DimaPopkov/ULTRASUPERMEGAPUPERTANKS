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
        
        /// <summary>
        /// Все башни
        /// </summary>
        readonly Dictionary<string, Tower> Towers = new Dictionary<string, Tower>();

        public MainForm()
        {
            InitializeComponent();

            Tower tower1 = new Tower
            {
                Name = "Башня1",
                Picture = Image.FromFile("../../Pictures/Towers/Тигр.jpg"),
                Price = 10000
            };
            Tower tower2 = new Tower
            {
                Name = "Башня2",
                Picture = Image.FromFile("../../Pictures/Towers/Тигр.jpg"),
                Price = 15000
            };

            Towers.Add(tower1.Name, tower1);
            Towers.Add(tower2.Name, tower2);

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


            int n = 0;
            tabPage2.Controls.Clear();
            foreach (var tower in Towers)
            {
                PictureBox pb = new PictureBox();
                pb.Tag = tower.Key;
                pb.Location = new Point(10 + n * 120, 10);
                pb.Size = new Size(100, 100);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = tower.Value.Picture;
                pb.Click += new EventHandler(TowerClick);
                tabPage2.Controls.Add(pb);

                n = n + 1;
            }
        }

        private void TowerClick(object sender, EventArgs e)
        {
            foreach (Control ctrl in tabPage2.Controls)
                ctrl.BackColor = Color.Transparent;

            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Gray;
            Tanks[comboBox1.Text].TankTower = Towers[pb.Tag.ToString()];
        }
        
        private void TimerTick(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;

            Tank currentTank = Tanks[comboBox1.Text];
            pictureBox1.Image = currentTank.Picture;
            int Price = currentTank.Price;
            if (currentTank.TankTower != null)
                Price += currentTank.TankTower.Price;

            label3.Text = "Стоимость: " + Price.ToString() + " рублей";
            label2.Text = "Мощность: " + currentTank.Power.ToString() + " л.с.";
        }
    }
}

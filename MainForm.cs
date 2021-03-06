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

            //Модели танков из БД
            List<string> tan = SQLClass.Select("SELECT Name, Power, Price FROM tanks ORDER BY id");
            List<Image> pics = SQLClass.SelectImages("SELECT Picture FROM tanks ORDER BY id");

            for (int i = 0; i < pics.Count; i++)
            {
                Tank tank = new Tank
                {
                    Name = tan[3 * i],
                    Power = Convert.ToInt32(tan[3 * i + 1]),
                    Price = Convert.ToInt32(tan[3 * i + 2]),
                    Picture = pics[i]
                };

                Tanks.Add(tank.Name, tank);
            }

            //Модели башен из БД
            List<string> towers = SQLClass.Select("SELECT Name, Price FROM towers ORDER BY id");
            pics = SQLClass.SelectImages("SELECT Picture FROM towers ORDER BY id");

            for (int i = 0; i < pics.Count; i++)
            {
                Tower tower = new Tower
                {
                    Name = towers[2 * i],
                    Price = Convert.ToInt32(towers[2 * i + 1]),
                    Picture = pics[i]
                };

                Towers.Add(tower.Name, tower);
            }

            //Добавление моделей танков на форму
            comboBox1.Items.Clear();
            foreach (var tank in Tanks)
                comboBox1.Items.Add(tank.Key);


            //Добавление моделей башен на форму
            int n = 0;
            towerTabPage.Controls.Clear();
            foreach (var tower in Towers)
            {
                PictureBox pb = new PictureBox();
                pb.Tag = tower.Key;
                pb.Location = new Point(10 + n * 120, 10);
                pb.Size = new Size(100, 100);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = tower.Value.Picture;
                pb.Click += new EventHandler(TowerClick);
                toolTip1.SetToolTip(pb, tower.Value.Name);
                towerTabPage.Controls.Add(pb);

                n = n + 1;
            }
        }

        private void TowerClick(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;

            //Все невыделено
            foreach (Control ctrl in towerTabPage.Controls)
                ctrl.BackColor = Color.Transparent;

            //Нужную башню выделяю
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

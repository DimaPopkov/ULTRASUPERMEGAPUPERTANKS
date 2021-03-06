using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Tank
    {
        /// <summary>
        /// Название модели
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public Image Picture { get; set; }

        /// <summary>
        /// Мощность
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Башня
        /// </summary>
        public Tower TankTower { get; set; }
    }
}

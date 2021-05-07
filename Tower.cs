using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    /// <summary>
    /// Башня
    /// </summary>
    public class Tower
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>
        public Image Picture { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Масса
        /// </summary>
        public int Mass { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Burger : Product
    {
        /// <summary>
        /// Weight in grams
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// BeefWeight in grams
        /// </summary>
        public int? BeefWeight { get; set; }

        /// <summary>
        /// List of menu linked to the current burger
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }

        /// <summary>
        /// Type of bread used by the burger
        /// </summary>
        public virtual Bread Bread { get; set; }
    }
}


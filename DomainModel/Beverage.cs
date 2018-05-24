using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Beverage : Product
    {
        /// <summary>
        /// Capacity in milliliter
        /// </summary>
        public double Milliliter { get; set; }

        /// <summary>
        /// Carbonated drink or not
        /// </summary>
        public bool IsCarbonated { get; set; }

        /// <summary>
        /// List of menu linked to the current beverage
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Dessert : Product
    {
        /// <summary>
        /// Capacity in milliliter
        /// </summary>
        public double Milliliter { get; set; }

        /// <summary>
        /// Need refrigeration or not
        /// </summary>
        public bool IsFrozen { get; set; }

        /// <summary>
        /// List of menu linked to the current dessert
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }
    }
}

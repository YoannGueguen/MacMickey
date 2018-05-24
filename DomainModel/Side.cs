using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Side : Product
    {
        /// <summary>
        /// Weight in grams
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// SaltWeight in grams
        /// </summary>
        public int? SaltWeight { get; set; }

        /// <summary>
        /// List of menu linked to the current side
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }
    }
}

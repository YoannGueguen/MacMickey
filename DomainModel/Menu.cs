using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Menu : Product
    {
        /// <summary>
        /// A link to a burger is required but without navigation property from burger to menu
        /// </summary>
        public virtual Burger Burger { get; set; }

        /// <summary>
        /// A link to a beverage is required but without navigation property from beverage to menu
        /// </summary>
        public virtual Beverage Beverage { get; set; }

        /// <summary>
        /// A link to a side is required but without navigation property from side to menu
        /// </summary>
        public virtual Side Side { get; set; }

        /// <summary>
        /// A link to a dessert is "optional" but without navigation property from dessert to menu
        /// </summary>
        public virtual Dessert Dessert { get; set; }
    }
}

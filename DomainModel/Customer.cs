
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Customer : Person
    {

        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public virtual Employee Advisor { get; set; }

        /// <summary>
        /// List of menu linked to the current beverage
        /// </summary>
        //public virtual ICollection<Menu> Menus { get; set; }
    }
}

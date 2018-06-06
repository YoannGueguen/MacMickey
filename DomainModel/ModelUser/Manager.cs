using System.Collections.Generic;

namespace MacMickey.DomainModel
{
    public class Manager : Person
    {
        public string OfficeName { get; set; }
        public bool IsJunior { get; set; }

        public virtual ICollection<Employee> ListEmployees { get; set; }

        /// <summary>
        /// List of menu linked to the current beverage
        /// </summary>
        //public virtual ICollection<Menu> Menus { get; set; }
    }
}

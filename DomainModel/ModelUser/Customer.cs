
using MacMickey.DomainModel.ModelOrder;
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

        public ICollection<Order> Orders { get; set; }
        public BasketCardItem BasketCard { get; set; }
    }
}

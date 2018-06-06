using MacMickey.DomainModel.ModelUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel.ModelOrder
{
    public class Order : AuditableEntity
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public string Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public bool IsValidate { get; set; } 

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public BasketCard BasketCard { get; set; }
    }
}

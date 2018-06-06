using MacMickey.DomainModel.ModelOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MacMickey.DomainModel
{
    public class BasketCard
    {
        public BasketCard()
        {
            CreatedOn = DateTimeOffset.Now;
            IsActive = true;
        }

        [Key]
        public string BasketCardId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public Customer Customer { get; set; }
        public decimal? ShippingAmount { get; set; }

        public virtual ICollection<BasketCardItem> BasketCardItems { get; set; }

    }
}

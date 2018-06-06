using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MacMickey.DomainModel.ModelOrder
{
    public class BasketCardItem
    {
        [Key]
        public int BasketCardItemID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public BasketCard BasketCard { get; set; }
    }
}

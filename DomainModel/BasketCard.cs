using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MacMickey.DomainModel
{
    public class BasketCard
    {
        [Key]
        public string BasketCardId { get; set; }
        public string CardId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}

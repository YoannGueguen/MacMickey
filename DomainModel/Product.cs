using MacMickey.DomainModel.ModelOrder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public abstract class Product
    {
        /// <summary>
        /// Primary key of the product table
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        /// <remarks>50 chars max</remarks>
        public string Name { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the product
        /// </summary>
        /// <remarks>300 chars max</remarks>
        public string Description { get; set; }

        /// <summary>
        /// Available items of this product
        /// </summary>
        public int Stockpiled { get; set; }

        public ICollection<BasketCardItem> BasketCardItems { get; set; }
    }
}

using MacMickey.Dal;
using MacMickey.DomainModel;
using MacMickey.DomainModel.ModelOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Services
{
    public class BasketCardsService
    {
        private readonly MacContext context;

        public BasketCardsService(MacContext context)
        {
            this.context = context;
        }

        public async Task AddToCart(long userId, long productId, int quantity)
        {
            var basketCard = context.BasketCards.FirstOrDefault(x => x.Customer.PersonId == userId && x.IsActive);

            if (basketCard == null)
            {
                basketCard = new BasketCard
                {
                    Customer = context.Customers.FirstOrDefault(p => p.PersonId == userId)
                };

                context.BasketCards.Add(basketCard);
            }
            var basketCardItem = basketCard.BasketCardItems.FirstOrDefault(x => x.Product.ProductID == productId);
            if (basketCardItem == null)
            {
                basketCardItem = new BasketCardItem
                {
                    BasketCard = basketCard,
                    Product = context.Products.FirstOrDefault(p => p.ProductID == productId),
                    Quantity = quantity
                };

                basketCard.BasketCardItems.Add(basketCardItem);
            }
            else
            {
                basketCardItem.Quantity = quantity;
            }

            await context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacMickeyWeb.Services
{
    public interface IBasketCardsService
    {
        Task AddToCart(long userId, long productId, int quantity);

    }
}

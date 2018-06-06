using MacMickey.Dal;
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
    }
}

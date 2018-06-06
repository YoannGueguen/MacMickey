using MacMickey.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacMickeyAPI.Services
{
    public class OrderService
    {
        private readonly MacContext context;

        public OrderService(MacContext context)
        {
            this.context = context;
        }
    }
}

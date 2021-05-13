using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DB
{
    public class ShoppingCartItem
    {
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }
    }
}

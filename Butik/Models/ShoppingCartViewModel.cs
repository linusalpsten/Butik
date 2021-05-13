using StoreAssortment.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ShoppingCartViewModel
    {
        public StoreAssortmentItem[] Items { get; set; }
    }
}

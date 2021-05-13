using StoreAssortment.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class StoreViewModel
    {
        public StoreAssortmentItem[] StoreAssortment { get; set; }
        public Guid[] Cart { get; set; }
    }
}

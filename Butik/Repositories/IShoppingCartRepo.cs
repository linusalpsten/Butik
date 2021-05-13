using ShoppingCart.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories
{
    public interface IShoppingCartRepo
    {
        Task<bool> Add(ShoppingCartItem item);
        Task<bool> Add(Guid CartId, Guid ItemId);
        Task<bool> Remove(ShoppingCartItem item);
        Task<bool> Remove(Guid CartId, Guid ItemId);
        Task<Guid[]> Clear(Guid cartId);
        Task<Guid[]> Get(Guid cartId);
    }
}

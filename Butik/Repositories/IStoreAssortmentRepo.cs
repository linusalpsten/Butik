using StoreAssortment.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories
{
    public interface IStoreAssortmentRepo
    {
        Task<StoreAssortmentItem[]> GetAll();
        Task<StoreAssortmentItem> GetById(Guid Id);
    }
}

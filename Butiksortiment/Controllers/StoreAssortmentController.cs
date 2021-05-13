using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAssortment.DB;

namespace StoreAssortment.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StoreAssortmentController : ControllerBase
    {
        private readonly StoreAssortmentContext _context;
        public StoreAssortmentController(StoreAssortmentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public StoreAssortmentItem[] GetAll()
        {
            return _context.StoreAssortmentItems.ToArray();
        }

        [HttpGet]
        public StoreAssortmentItem GetById(Guid Id)
        {
            return _context.StoreAssortmentItems.Where(sa => sa.Id == Id).SingleOrDefault();
        }
    }
}

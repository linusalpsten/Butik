using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartContext _context;
        public ShoppingCartController(ShoppingCartContext context)
        {
            _context = context;
        }
        [HttpPost]
        public bool Add(ShoppingCartItem item)
        {
            try
            {
                _context.ShoppingCartItems.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        [HttpPost]
        public bool Remove(ShoppingCartItem item)
        {
            try
            {
                _context.ShoppingCartItems.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        [HttpPost]
        public Guid[] Clear([FromBody]Guid cartId)
        {
            try
            {
                var items = _context.ShoppingCartItems.Where(sc => sc.CartId == cartId).ToArray();
                _context.ShoppingCartItems.RemoveRange(items);
                _context.SaveChanges();
                return items.Select(ki => ki.ItemId).ToArray();
            }
            catch (DbUpdateException)
            {
                return new Guid[0];
            }
        }

        [HttpGet]
        public Guid[] Get(Guid cartId)
        {
            return _context.ShoppingCartItems.Where(sc => sc.CartId == cartId).Select(ki => ki.ItemId).ToArray();
        }
    }
}

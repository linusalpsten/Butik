using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Models;
using Store.Repositories;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreAssortmentRepo _storeAssortmentRepo;
        private readonly IShoppingCartRepo _shoppingCartRepo;
        public HomeController(IStoreAssortmentRepo storeAssortmentRepo, IShoppingCartRepo shoppingCartRepo)
        {
            _storeAssortmentRepo = storeAssortmentRepo;
            _shoppingCartRepo = shoppingCartRepo;
        }

        public async Task<IActionResult> Index()
        {
            var shoppingCartId = ShoppingCartId();
            var vm = new StoreViewModel();
            vm.StoreAssortment = await _storeAssortmentRepo.GetAll();
            vm.Cart = await _shoppingCartRepo.Get(shoppingCartId);
            return View(vm);
        }

        public async Task<IActionResult> AddToCart(Guid Id)
        {
            var shoppingCartId = ShoppingCartId();
            await _shoppingCartRepo.Add(shoppingCartId, Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShoppingCart()
        {
            var shoppingCartId = ShoppingCartId();
            var vm = new ShoppingCartViewModel();
            var cart = await _shoppingCartRepo.Get(shoppingCartId);
            vm.Items = (await _storeAssortmentRepo.GetAll()).Where(si => cart.Contains(si.Id)).ToArray();
            return View(vm);
        }

        public async Task<IActionResult> RemoveFromCart(Guid Id)
        {
            var shoppingCartId = ShoppingCartId();
            await _shoppingCartRepo.Remove(shoppingCartId, Id);
            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> Checkout()
        {
            var shoppingCartId = ShoppingCartId();
            await _shoppingCartRepo.Clear(shoppingCartId);
            return RedirectToAction("Index");
        }

        private Guid ShoppingCartId()
        {
            Guid Id;
            var cartId = Request.Cookies["ShoppingCart"];
            if (cartId == null)
            {
                Id = Guid.NewGuid();
                Response.Cookies.Append("ShoppingCart", Id.ToString());
            }
            else
            {
                Id = new Guid(cartId);
            }
            return Id;
        }
    }
}

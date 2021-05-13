using Newtonsoft.Json;
using ShoppingCart.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.Repositories
{
    public class ShoppingCartRepo : IShoppingCartRepo
    {
        private readonly HttpClient _client;
        public ShoppingCartRepo(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

        public async Task<bool> Add(ShoppingCartItem item)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Add");
            message.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
            var result = await _client.SendAsync(message);
            return JsonConvert.DeserializeObject<bool>(await result.Content.ReadAsStringAsync());
        }

        public async Task<bool> Add(Guid CartId, Guid ItemId)
        {
            return await Add(new ShoppingCartItem { CartId = CartId, ItemId = ItemId });
        }

        public async Task<bool> Remove(ShoppingCartItem item)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Remove");
            message.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
            var result = await _client.SendAsync(message);
            return JsonConvert.DeserializeObject<bool>(await result.Content.ReadAsStringAsync());
        }

        public async Task<bool> Remove(Guid CartId, Guid ItemId)
        {
            return await Remove(new ShoppingCartItem { CartId = CartId, ItemId = ItemId });
        }

        public async Task<Guid[]> Clear(Guid cartId)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Clear");
            message.Content = new StringContent(JsonConvert.SerializeObject(cartId), null, "application/json");
            var result = await _client.SendAsync(message);
            return JsonConvert.DeserializeObject<Guid[]>(await result.Content.ReadAsStringAsync());
        }

        public async Task<Guid[]> Get(Guid cartId)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44357/ShoppingCart/Get?cartId=" + cartId.ToString());
            var result = await _client.SendAsync(message);
            return JsonConvert.DeserializeObject<Guid[]>(await result.Content.ReadAsStringAsync());
        }
    }
}

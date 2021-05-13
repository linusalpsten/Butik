using Newtonsoft.Json;
using ShoppingCart.DB;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCartTests
{
    public class Tests
    {
        [Fact]
        public async Task AddTest()
        {
            HttpClient client = new HttpClient();
            Guid cartId = Guid.NewGuid();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Add");
            ShoppingCartItem item = new ShoppingCartItem { CartId = cartId, ItemId = Guid.NewGuid() };
            message.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
            var addResult = await client.SendAsync(message);
            bool success = JsonConvert.DeserializeObject<bool>(await addResult.Content.ReadAsStringAsync());
            Assert.True(success, "Successfully added an item to shopping cart");
        }

        [Fact]
        public async Task RemoveTest()
        {
            // add some thing first
            HttpClient client = new HttpClient();
            Guid cartId = Guid.NewGuid();
            HttpRequestMessage addMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Add");
            ShoppingCartItem item = new ShoppingCartItem { CartId = cartId, ItemId = Guid.NewGuid() };
            addMessage.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
            var result = await client.SendAsync(addMessage);
            bool success = JsonConvert.DeserializeObject<bool>(await result.Content.ReadAsStringAsync());
            if (success)
            {
                HttpRequestMessage clearMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Remove");
                clearMessage.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
                await client.SendAsync(clearMessage);
                HttpRequestMessage getMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44357/ShoppingCart/Get?basketId=" + cartId.ToString());
                var getResult = await client.SendAsync(getMessage);
                var cart = JsonConvert.DeserializeObject<Guid[]>(await getResult.Content.ReadAsStringAsync());
                Assert.DoesNotContain(item.ItemId, cart);
            }
        }

        [Fact]
        public async Task ClearTest()
        {
            // add some thing first
            HttpClient client = new HttpClient();
            Guid cartId = Guid.NewGuid();
            HttpRequestMessage addMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Add");
            ShoppingCartItem item = new ShoppingCartItem { CartId = cartId, ItemId = Guid.NewGuid() };
            addMessage.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
            var result = await client.SendAsync(addMessage);
            bool success = JsonConvert.DeserializeObject<bool>(await result.Content.ReadAsStringAsync());
            if (success)
            {
                HttpRequestMessage clearMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44357/ShoppingCart/Clear");
                clearMessage.Content = new StringContent(JsonConvert.SerializeObject(cartId), null, "application/json");
                await client.SendAsync(clearMessage);
                HttpRequestMessage getMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44357/ShoppingCart/Get?basketId="+cartId.ToString());
                var getResult = await client.SendAsync(getMessage);
                var cart = JsonConvert.DeserializeObject<Guid[]>(await getResult.Content.ReadAsStringAsync());
                Assert.DoesNotContain(item.ItemId, cart);
            }
        }
    }
}

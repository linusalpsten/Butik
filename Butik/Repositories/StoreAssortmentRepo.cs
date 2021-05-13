using Newtonsoft.Json;
using StoreAssortment.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.Repositories
{
    public class StoreAssortmentRepo : IStoreAssortmentRepo
    {
        private readonly HttpClient _client;
        public StoreAssortmentRepo(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

        public async Task<StoreAssortmentItem[]> GetAll()
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44361/StoreAssortment/GetAll");
            var result = await _client.SendAsync(message);
            return JsonConvert.DeserializeObject<StoreAssortmentItem[]>(await result.Content.ReadAsStringAsync());
        }

        public async Task<StoreAssortmentItem> GetById(Guid Id)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44361/StoreAssortment/GetById?Id=" + Id);
            var result = await _client.SendAsync(message);
            return JsonConvert.DeserializeObject<StoreAssortmentItem>(await result.Content.ReadAsStringAsync());
        }
    }
}

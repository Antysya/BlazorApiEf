using Models;
using System.Net.Http.Json;

namespace ShopClient
{
    public class ShopClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _host;
        public ShopClient(HttpClient httpClient, string host)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentException($"'{nameof(host)}' host не может быть пустым"); 
            }
            if(httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient));    
            }
            _httpClient = httpClient;
            _host = host;
        }

        public async Task<IReadOnlyList<Product>>GetProductsAsync()
        {
            var uri = $"{_host}/api/products";
            var products = await _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>(uri);
            return products!;
        }
    }
}
using InventoryMVCCoreWeb.Models;

namespace InventoryMVCCoreWeb.Services
{
    public class InventoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public InventoryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var baseAddress = configuration["InventoryApiService"];
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentNullException(nameof(baseAddress), "InventoryApiService configuration is missing or null.");
            _httpClient.BaseAddress = new Uri(baseAddress);
            _configuration = configuration;
        }

        public async Task<List<ProductViewModel>> GetInventoryProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/inventory/product");
            response.EnsureSuccessStatusCode();
            var items = await response.Content.ReadFromJsonAsync<List<ProductViewModel>>();
            return items ?? new List<ProductViewModel>();
        }

        public async Task<ProductViewModel?> GetInventoryProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/inventory/product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadFromJsonAsync<ProductViewModel>();
                return item;
            }
            return null;
        }

        public async Task<bool> AddInventoryProductAsync(ProductViewModel product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/inventory/product", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateInventoryProductAsync(ProductViewModel product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/inventory/product/{product.Id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteInventoryProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/inventory/product/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

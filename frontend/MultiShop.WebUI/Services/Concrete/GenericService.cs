using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete
{
    public class GenericService<TResult, TCreate, TUpdate>
      : IGenericService<TResult, TCreate, TUpdate>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _endpoint;

        public GenericService(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<List<TResult>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_endpoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<TResult>>();
        }

        public async Task<TResult> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResult>();
        }

        public async Task CreateAsync(TCreate createDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_endpoint, createDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(TUpdate updateDto)
        {
            var response = await _httpClient.PutAsJsonAsync(_endpoint, updateDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}?id={id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

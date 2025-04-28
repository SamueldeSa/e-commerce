using EcommerceFrontBlazor.Models.ProdutoModels;
using System.Net.Http.Json;

namespace EcommerceFrontBlazor.Services
{
    public class ProdutoService
    {
        private readonly HttpClient _httpClient;

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Produto>>("api/produtos");
        }

        public async Task<Produto> GetProdutoByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Produto>($"api/produtos/{id}");
        }

        public async Task CreateProdutoAsync(Produto produto)
        {
            await _httpClient.PostAsJsonAsync("api/produtos", produto);
        }

        public async Task UpdateProdutoAsync(Guid id, Produto produto)
        {
            await _httpClient.PutAsJsonAsync($"api/produtos/{id}", produto);
        }

        public async Task DeleteProdutoAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/produtos/{id}");
        }
    }
}

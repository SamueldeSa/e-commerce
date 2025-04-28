using EcommerceFrontBlazor.Models.ClienteModels;
using System.Net.Http.Json;

namespace EcommerceFrontBlazor.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes");
        }

        public async Task<Cliente> GetClienteByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
        }

        public async Task CreateClienteAsync(Cliente cliente)
        {
            await _httpClient.PostAsJsonAsync("api/clientes", cliente);
        }

        public async Task UpdateClienteAsync(Guid id, Cliente cliente)
        {
            await _httpClient.PutAsJsonAsync($"api/clientes/{id}", cliente);
        }

        public async Task DeleteClienteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/clientes/{id}");
        }
    }
}

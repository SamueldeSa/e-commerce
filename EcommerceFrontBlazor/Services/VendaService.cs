using EcommerceFrontBlazor.Models.AnaliseModels;
using EcommerceFrontBlazor.Models.VendaModels;
using System.Net.Http.Json;

namespace EcommerceFrontBlazor.Services
{
    public class VendaService
    {
        private readonly HttpClient _httpClient;

        public VendaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<VendaResponse>> GetVendasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<VendaResponse>>("api/venda");
        }

        public async Task<VendaResponse> GetVendaByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<VendaResponse>($"api/venda/{id}");
        }

        public async Task CreateVendaAsync(CreateVenda venda)
        {
            await _httpClient.PostAsJsonAsync("api/venda", venda);
        }
        public async Task<AnaliseVendasResponse> GetAnaliseVendasAsync(DateTime dataInicio, DateTime dataFim)
        {
            var url = $"api/venda/analise?dataInicio={dataInicio:O}&dataFim={dataFim:O}";
            return await _httpClient.GetFromJsonAsync<AnaliseVendasResponse>(url);
        }


        public async Task DeleteVendaAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/venda/{id}");
        }
    }
}

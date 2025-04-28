
using EcommerceFrontBlazor.Models.ProdutoModels;

namespace EcommerceFrontBlazor.Models.AnaliseModels
{
    public class AnaliseVendasResponse
    {
        public decimal RendaTotal { get; set; }
        public int Quantidade { get; set; }
        public List<ProdutoRendaResponse> ProdutosRenda { get; set; } = new();
    }
}

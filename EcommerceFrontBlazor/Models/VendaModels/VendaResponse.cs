using EcommerceFrontBlazor.Models.ProdutoModels;

namespace EcommerceFrontBlazor.Models.VendaModels
{
    public class VendaResponse
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string nomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
        public List<ProdutoVendidoResponse> ProdutosVendidos { get; set; } = new();
    }
}

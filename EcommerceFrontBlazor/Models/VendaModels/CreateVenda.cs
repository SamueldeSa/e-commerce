
using EcommerceFrontBlazor.Models.ProdutoModels;

namespace EcommerceFrontBlazor.Models.VendaModels
{
    public class CreateVenda
    {
        public Guid ClienteId { get; set; }
        public List<ProdutosVendidos> Produtos { get; set; } = new();
    }
}

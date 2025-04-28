namespace EcommerceFrontBlazor.Models.ProdutoModels
{
    public class ProdutoVendidoResponse
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; } // (só se quiser exibir o nome do produto)
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}

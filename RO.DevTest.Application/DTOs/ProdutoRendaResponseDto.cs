using System;

namespace RO.DevTest.Application.DTOs
{
    public class ProdutoRendaResponseDto
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public decimal RendalTotal { get; set; }
        
    }
}

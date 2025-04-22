using System;
using System.Security;

namespace RO.DevTest.Application.DTOs
{
    public class UpdateProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }


    }
}

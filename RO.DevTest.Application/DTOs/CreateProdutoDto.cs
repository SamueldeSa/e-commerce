using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace RO.DevTest.Application.DTOs
{
    public class CreateProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco  { get; set; }
        


    }
}

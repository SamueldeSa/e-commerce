using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.DTOs
{
    public class VendaResponseDto
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
        public List<ProdutoVendidoResponseDto> ProdutosVendidos { get; set; }


    }
}

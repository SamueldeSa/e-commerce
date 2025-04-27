using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.DTOs
{
    public class AnaliseVendasResponseDto
    {
        public int Quantidade { get; set; }
        public decimal RendaTotal { get; set; }
        public List<ProdutoRendaResponseDto> ProdutosRenda { get; set; }

    }
}

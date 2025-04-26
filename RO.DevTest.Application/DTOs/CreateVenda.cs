using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.DTOs
{
    internal class CreateVenda
    {
        public Guid ClienteId { get; set; }
        public List<ProdutoVendidoDto> Produtos { get; set; }


    }
}

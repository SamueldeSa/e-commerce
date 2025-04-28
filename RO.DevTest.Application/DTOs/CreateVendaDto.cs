using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.DTOs
{
    public class CreateVendaDto
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }    
        public List<ProdutoVendidoDto> Produtos { get; set; }


    }
}

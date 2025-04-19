using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }

        public Cliente? Cliente { get; set; }
        public ICollection<ProdutoVendido> ProdutosVendidos { get; set; }

    }
}

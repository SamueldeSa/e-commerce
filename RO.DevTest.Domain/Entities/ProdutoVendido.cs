using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Domain.Entities
{
    public class ProdutoVendido
    {
        public Guid Id { get; set; }
        public Guid VendaId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Venda? Venda { get; set; }
        public Produto? Produto{ get; set; }
    }
}

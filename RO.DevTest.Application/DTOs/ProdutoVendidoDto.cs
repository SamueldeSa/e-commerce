﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.DTOs
{
    public class ProdutoVendidoDto
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario {  get; set; }



    }
}

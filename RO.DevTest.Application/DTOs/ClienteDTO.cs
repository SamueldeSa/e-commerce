using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.DTOs
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }


    }
}

﻿namespace EcommerceFrontBlazor.Models.ClienteModels
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime dataNascimento { get; set; }


    }
}

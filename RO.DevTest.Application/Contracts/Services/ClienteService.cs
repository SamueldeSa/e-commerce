using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Contracts.Services
{
    internal class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {

            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> CreateAsync(CreateClienteDto dto)
        {
            var Cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento
            };

            await _clienteRepository.AddAsync(Cliente);
            await _clienteRepository.SaveChangesAsync();

            return new ClienteDTO
            {
                Id = Cliente.Id,
                Nome = Cliente.Nome,
                Email = Cliente.Email,
                Cpf = Cliente.Cpf,
                DataNascimento = dto.DataNascimento

            };

        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(Id);
            if (cliente == null) return false;

            _clienteRepository.Remove(cliente);
            await _clienteRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();

            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Cpf= c.Cpf,
                DataNascimento= c.DataNascimento   
            });

        }

        public async Task<ClienteDTO?> GetByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if(cliente == null) return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento
            };

        }

        public async Task<bool> UpdateAsync(Guid Id, UpdateClienteDto dto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(Id);
            if (cliente == null) return false;

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.DataNascimento = dto.DataNascimento;

            _clienteRepository.Updade(cliente);
            await _clienteRepository.SaveChangesAsync();

            return true;


        }


    }
}

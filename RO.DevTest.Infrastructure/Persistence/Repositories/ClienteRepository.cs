using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

         

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);       
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public void Remove(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);  
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}

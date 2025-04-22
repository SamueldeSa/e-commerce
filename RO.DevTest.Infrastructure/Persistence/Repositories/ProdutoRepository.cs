using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Infrastructure.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(Guid Id)
        {
            return await _context.Produtos.FindAsync(Id);
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Remove(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

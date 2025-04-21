using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetByIdAsync(Guid Id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task AddAsync(Produto produto); 
        void Update(Produto produto);     
        void Remove(Guid Id);
        Task SaveChangesAsync();    

    }
}

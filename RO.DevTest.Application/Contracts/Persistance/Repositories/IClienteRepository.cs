using RO.DevTest.Application.DTOs;
using System.Threading.Tasks;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(Guid id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task AddAsync(Cliente cliente);
        void Updade(Cliente cliente);
        void Remove(Cliente cliente);
        Task SaveChangesAsync();

    }
}

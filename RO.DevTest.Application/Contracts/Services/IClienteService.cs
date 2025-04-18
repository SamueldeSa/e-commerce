using RO.DevTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Contracts.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO> CreateAsync(CreateClienteDto dto);
        Task<bool> UpdateAsync(Guid Id, UpdateClienteDto dto);
        Task<bool> DeleteAsync(Guid Id);
    }
}

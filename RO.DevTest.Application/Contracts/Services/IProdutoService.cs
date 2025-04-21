
using RO.DevTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Contracts.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto?> GetByAsync(Guid id); 
        Task<IEnumerable<ProdutoDto>> GetAllAync();
        Task<ProdutoDto> CreateAsync(CreateProdutoDto dto);
        Task<bool>UpdateAsync(Guid Id, UpdateProdutoDto dto);
        Task<bool> DeleteAysnc(Guid Id);

    }
}

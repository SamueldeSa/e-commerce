using RO.DevTest.Domain.Entities;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.Application.Contracts.Services.Interface
{
    public interface IVendaService
    {
        Task<VendaResponseDto> CriarVendaAsync(CreateVendaDto createVendaDto);
        Task<List<VendaResponseDto>> ListVendaAsync();
        Task<VendaResponseDto> ObterVendaPorIdAsync(Guid id);
        Task<bool> DeletarVendaAsync(Guid id);
        Task<AnaliseVendasResponseDto> ObterAnaliseVendasAsync(DateTime dataInicio, DateTime dataFim);

    }
}

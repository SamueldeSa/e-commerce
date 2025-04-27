using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Services.Interface;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Infrastructure.Persistence;

namespace RO.DevTest.Infrastructure.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;

        public VendaService(AppDbContext context)
        {
             _context = context;
        }

        public async Task<VendaResponseDto> CriarVendaAsync(CreateVendaDto createVendaDto)
        {
            var venda = new Venda
            {
                ClienteId = createVendaDto.ClienteId,
                DataVenda = DateTime.UtcNow,
                ValorTotal = createVendaDto.Produtos.Sum(p => p.PrecoUnitario * p.Quantidade),
                ProdutosVendidos = createVendaDto.Produtos.Select(produto => new ProdutoVendido
                {
                    ProdutoId = produto.ProdutoId,
                    Quantidade = produto.Quantidade,
                    PrecoUnitario = produto.PrecoUnitario
                }).ToList()
            };

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            var vendaResponse = new VendaResponseDto
            {
                Id = venda.Id,
                ClienteId = venda.ClienteId,
                DataVenda = venda.DataVenda,
                ValorTotal = venda.ValorTotal,
                ProdutosVendidos = venda.ProdutosVendidos.Select(pv => new ProdutoVendidoResponseDto
                {
                    ProdutoId = pv.ProdutoId,
                    Quantidade = pv.Quantidade,
                    PrecoUnitario = pv.PrecoUnitario
                }).ToList()
            };

            return vendaResponse;
            


        }

        public async Task<List<VendaResponseDto>> ListVendaAsync()
        {
            var vendas = await _context.Vendas
                .Include(v => v.ProdutosVendidos)
                .ToListAsync();

            var vendasResponse = vendas.Select(venda => new VendaResponseDto
            {
                Id = venda.Id,
                ClienteId = venda.ClienteId,
                DataVenda = venda.DataVenda,
                ValorTotal= venda.ValorTotal,
                ProdutosVendidos = venda.ProdutosVendidos.Select(pv => new ProdutoVendidoResponseDto
                {
                    ProdutoId = pv.ProdutoId,
                    Quantidade = pv.Quantidade,
                    PrecoUnitario = pv.PrecoUnitario
                }).ToList()
            }).ToList();

            return vendasResponse;  
        }


        public async Task<VendaResponseDto> ObterVendaPorIdAsync(Guid id)
        {
            var venda =  await _context.Vendas
                .Include(v => v.ProdutosVendidos)
                .FirstOrDefaultAsync(v => v.Id == id);

            if(venda == null)
            {
                throw new KeyNotFoundException($"Venda com Id {id} não escontrado");
            }

            var vendaResponseDto = new VendaResponseDto
            {
                Id = venda.Id,
                ClienteId = venda.ClienteId,
                DataVenda = venda.DataVenda,
                ValorTotal = venda.ValorTotal,
                ProdutosVendidos = venda.ProdutosVendidos.Select(pv => new ProdutoVendidoResponseDto
                {
                    ProdutoId = pv.ProdutoId,
                    Quantidade = pv.Quantidade,
                    PrecoUnitario = pv.PrecoUnitario
                }).ToList()
            };

            return vendaResponseDto;
        }



        public async Task<bool> DeletarVendaAsync(Guid id)
        {
            var venda = await _context.Vendas.FindAsync(id);    
            if(venda == null) return false;

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return true;

        }

       

        
    }
}

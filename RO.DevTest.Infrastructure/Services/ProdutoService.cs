using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Contracts.Services.Interface;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO.DevTest.Infrastructure.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> CreateAsync(CreateProdutoDto dto)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Estoque = dto.Estoque
            };

            await _produtoRepository.AddAsync(produto);
            await _produtoRepository.SaveChangesAsync();

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var produto = await _produtoRepository.GetByIdAsync(Id);
            if (produto == null) return false;

            _produtoRepository.Remove(produto);
            await _produtoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAync()
        {
            var produto = await _produtoRepository.GetAllAsync();
            return produto.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque
            });

        }

        public async Task<ProdutoDto?> GetByAsync(Guid Id)
        {
            var produto = await _produtoRepository.GetByIdAsync(Id);
            if (produto == null) return null;

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };
        }

        public async Task<bool> UpdateAsync(Guid Id, UpdateProdutoDto dto)
        {
            var produto = await _produtoRepository.GetByIdAsync(Id);
            if(produto == null) return false;

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Preco = dto.Preco;
            produto.Estoque = dto.Estoque;

            _produtoRepository.Update(produto);
            await _produtoRepository.SaveChangesAsync();
            return true;

        }
    }
}

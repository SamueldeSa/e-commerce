

using FluentAssertions;
using Moq;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Infrastructure.Services;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Tests.Unit.Application.Services
{
    public class ProdutoServiceTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTest()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object );
        }


        [Fact]
        public async Task CreateAsync_DeveRetornarProdutoDto_QuandoSucesso()
        {
            //Arrange
            var dto = new CreateProdutoDto
            {
                Nome = "Monitor",
                Descricao = "Monitor samsung",
                Preco = 1220,
                Estoque = 5
            };

            //Act
            var result = await _produtoService.CreateAsync( dto );

            //Assert
            result.Should().NotBeNull();
            result.Nome.Should().Be(dto.Nome);
            result.Descricao.Should().Be(dto.Descricao);
            result.Preco.Should().Be(dto.Preco);
            result.Estoque.Should().Be(dto.Estoque);

            _produtoRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Produto>()), Times.Once);
            _produtoRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);   
        }

        [Fact]
        public async Task UpdateAsync_DeveRetornarTrue_QuandoProdutoExixte()
        {
            var id = Guid.NewGuid();
            var produto = new Produto
            { Id = id, Nome = "SSD", Descricao = "Espaço 500 GB", Preco = 230, Estoque = 5 };
            var dto = new UpdateProdutoDto { Nome = "SSD", Descricao = "em falta ", Preco = 1, Estoque = 1 };

            _produtoRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(produto);

            var result = await _produtoService.UpdateAsync(id, dto);

            result.Should().BeTrue();
            _produtoRepositoryMock.Verify(r => r.Update(It.IsAny<Produto>()), Times.Once);
            _produtoRepositoryMock.Verify(r => r.SaveChangesAsync());
        }

        [Fact]
        public async Task UpdateAsync_DeveRetornarFalse_QuandoProdutoNaoExiste()
        {
            var id = Guid.NewGuid();
            _produtoRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Produto?)null);

            var result = await _produtoService.UpdateAsync(id, new UpdateProdutoDto());

            result.Should().BeFalse();
            _produtoRepositoryMock.Verify(r => r.Update(It.IsAny<Produto>()), Times.Never);
            _produtoRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);   

        }


        [Fact]
        public async Task DeleteAsync_DeveRetornarTrue_QuandoProdutoExiste()
        {
            // Arrange
            var id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto X", Preco = 300 };

            _produtoRepositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(produto);

            // Act
            var result = await _produtoService.DeleteAsync(id);

            // Assert
            result.Should().BeTrue();
            _produtoRepositoryMock.Verify(r => r.Remove(It.IsAny<Produto>()), Times.Once);
            _produtoRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

    }
}

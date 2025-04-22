using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Contracts.Services;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produto = await _produtoService.GetAllAync();
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var produto = await _produtoService.GetByAsync(id);
            if (produto == null) return NotFound();

            return Ok(produto); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProdutoDto dto)
        {
            var produto = await _produtoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = produto.Id}, produto);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProdutoDto dto)
        {
            var sucesso = await _produtoService.UpdateAsync(id, dto);
            if(!sucesso ) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await _produtoService.DeleteAsync(id);
            if(!sucesso) return NotFound();

            return NoContent();
        }

    }
}

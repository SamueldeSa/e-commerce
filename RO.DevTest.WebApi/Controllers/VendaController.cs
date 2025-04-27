using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Infrastructure.Services;
using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Application.Contracts.Services.Interface;


namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }


        [HttpPost]
        public async Task<ActionResult<Venda>> CriarVenda([FromBody] CreateVendaDto createVendaDto)
        {
            var vendaCriada = await _vendaService.CriarVendaAsync(createVendaDto);
            return CreatedAtAction(nameof(ObterVendaPorId), new { id = vendaCriada.Id }, vendaCriada);
        }

        [HttpGet]
        public async Task<ActionResult<List<VendaResponseDto>>> ListarVendas()
        {
            var vendas = await _vendaService.ListVendaAsync();
            return Ok(vendas);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaResponseDto>> ObterVendaPorId(Guid id)
        {
            var venda = await _vendaService.ObterVendaPorIdAsync( id);
            if (venda == null)
            {
                return NotFound($"Venda com ID {id} não encontrada!");
            }

            return Ok(venda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVenda(Guid id)
        {
            var sucesso = await _vendaService.DeletarVendaAsync(id);
            if (!sucesso)
            {
                return NotFound($"Venda com Id {id} não encontrado!");
            }

            return NoContent();

        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
            return CreatedAtAction(nameof(ObterCliente), new { id = cliente.Id }, cliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            await _clienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCliente(Guid id)
        {
            await _clienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

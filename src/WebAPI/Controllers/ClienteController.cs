using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rommanel.Application.Commands;
using Rommanel.Application.Queries;

namespace Rommanel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CreateClienteCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterCliente), new { id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var query = new GetClienteByIdQuery(id);
            var cliente = await _mediator.Send(query);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetClientesQuery(page, pageSize);
            var clientes = await _mediator.Send(query);
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, [FromBody] UpdateClienteCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID informado na URL não corresponde ao do cliente.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCliente(Guid id)
        {
            var command = new DeleteClienteCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rommanel.Application.Commands;
using Rommanel.Application.Queries;
using Rommanel.Domain.Entities;
using Rommanel.WebAPI.Models.Response;

[ApiController]
[Route("api/[controller]")]
public class ClienteController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CriarCliente([FromBody] CreateClienteCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterCliente), new { id }, ApiResponse<Guid>.Ok(id, "Cliente criado com sucesso."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterCliente(Guid id)
    {
        var cliente = await _mediator.Send(new GetClienteByIdQuery(id));

        if (cliente == null)
            return NotFound(ApiResponse<string>.Fail("Cliente não encontrado."));

        return Ok(ApiResponse<Cliente>.Ok(cliente));
    }

    [HttpGet]
    public async Task<IActionResult> ListarClientes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var clientes = await _mediator.Send(new GetClientesQuery(page, pageSize));
        return Ok(ApiResponse<IEnumerable<Cliente>>.Ok(clientes));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarCliente(Guid id, [FromBody] UpdateClienteCommand command)
    {
        if (id != command.Id)
            return BadRequest(ApiResponse<string>.Fail("O ID informado na URL não corresponde ao do cliente."));

        await _mediator.Send(command);
        return Ok(ApiResponse<string>.Ok("Cliente atualizado com sucesso."));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverCliente(Guid id)
    {
        await _mediator.Send(new DeleteClienteCommand(id));
        return Ok(ApiResponse<string>.Ok("Cliente removido com sucesso."));
    }
}

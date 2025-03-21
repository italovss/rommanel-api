using MediatR;
using Rommanel.Application.Commands;
using Rommanel.Application.Events;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class CreateClienteHandler(IClienteRepository clienteRepository, IMediator mediator) : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IMediator _mediator = mediator;

        public async Task<Guid> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(
                request.Nome,
                request.CPF_CNPJ,
                request.DataNascimento,
                request.Telefone,
                request.Email,
                request.Endereco
            );

            await _clienteRepository.AddAsync(cliente);
            await _mediator.Publish(new ClienteCriadoEvent(cliente.Id, cliente.Nome, cliente.Email), cancellationToken);

            return cliente.Id;
        }
    }
}

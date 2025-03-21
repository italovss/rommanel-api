using MediatR;
using Rommanel.Application.Commands;
using Rommanel.Application.Events;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class DeleteClienteHandler(IClienteRepository clienteRepository, IMediator mediator) : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IMediator _mediator = mediator;

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado");

            await _clienteRepository.DeleteAsync(request.Id);
            await _mediator.Publish(new ClienteRemovidoEvent(request.Id), cancellationToken);

            return Unit.Value;
        }
    }
}

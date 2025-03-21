using MediatR;
using Rommanel.Application.Commands;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class DeleteClienteHandler(IClienteRepository clienteRepository) : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado");

            await _clienteRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}

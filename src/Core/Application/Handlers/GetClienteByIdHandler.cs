using MediatR;
using Rommanel.Application.Queries;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class GetClienteByIdHandler(IClienteRepository clienteRepository) : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetByIdAsync(request.Id);
        }
    }
}

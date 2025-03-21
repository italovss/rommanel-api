using MediatR;
using Rommanel.Application.Queries;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class GetClientesHandler(IClienteRepository clienteRepository) : IRequestHandler<GetClientesQuery, IEnumerable<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<IEnumerable<Cliente>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes;
        }
    }
}

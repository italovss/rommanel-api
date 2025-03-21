using MediatR;
using Rommanel.Application.Commands;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class CreateClienteHandler(IClienteRepository clienteRepository) : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

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
            return cliente.Id;
        }
    }
}

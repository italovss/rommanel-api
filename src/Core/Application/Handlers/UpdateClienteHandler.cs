using MediatR;
using Rommanel.Application.Commands;
using Rommanel.Domain.Repositories;

namespace Rommanel.Application.Handlers
{
    public class UpdateClienteHandler(IClienteRepository clienteRepository) : IRequestHandler<UpdateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                throw new KeyNotFoundException("Cliente não encontrado");

            cliente = new(request.Nome, request.CPF_CNPJ, request.DataNascimento, request.Telefone, request.Email, request.Endereco);

            await _clienteRepository.UpdateAsync(cliente);
            return Unit.Value;
        }
    }
}

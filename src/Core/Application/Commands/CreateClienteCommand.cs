using MediatR;
using Rommanel.Domain.Entities;

namespace Rommanel.Application.Commands
{
    public class CreateClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
    }
}

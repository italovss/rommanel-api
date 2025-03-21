using MediatR;

namespace Rommanel.Application.Events
{
    public class ClienteAtualizadoEvent : INotification
    {
        public Guid ClienteId { get; }
        public string Nome { get; }
        public string Email { get; }

        public ClienteAtualizadoEvent(Guid clienteId, string nome, string email)
        {
            ClienteId = clienteId;
            Nome = nome;
            Email = email;
        }
    }
}

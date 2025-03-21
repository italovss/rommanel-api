using MediatR;

namespace Rommanel.Application.Events
{
    public class ClienteCriadoEvent : INotification
    {
        public Guid ClienteId { get; }
        public string Nome { get; }
        public string Email { get; }

        public ClienteCriadoEvent(Guid clienteId, string nome, string email)
        {
            ClienteId = clienteId;
            Nome = nome;
            Email = email;
        }
    }
}

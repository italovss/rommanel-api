using MediatR;

namespace Rommanel.Application.Events
{
    public class ClienteRemovidoEvent : INotification
    {
        public Guid ClienteId { get; }

        public ClienteRemovidoEvent(Guid clienteId)
        {
            ClienteId = clienteId;
        }
    }
}

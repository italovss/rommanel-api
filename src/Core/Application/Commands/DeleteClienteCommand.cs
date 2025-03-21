using MediatR;

namespace Rommanel.Application.Commands
{
    public class DeleteClienteCommand(Guid id) : IRequest
    {
        public Guid Id { get; } = id;
    }
}

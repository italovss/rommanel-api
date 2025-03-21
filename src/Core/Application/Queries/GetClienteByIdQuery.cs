using MediatR;
using Rommanel.Domain.Entities;

namespace Rommanel.Application.Queries
{
    public class GetClienteByIdQuery(Guid id) : IRequest<Cliente>
    {
        public Guid Id { get; } = id;
    }
}

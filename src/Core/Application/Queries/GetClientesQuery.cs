using MediatR;
using Rommanel.Domain.Entities;

namespace Rommanel.Application.Queries
{
    public class GetClientesQuery(int page, int pageSize) : IRequest<IEnumerable<Cliente>>
    {
        public int Page { get; } = page;
        public int PageSize { get; } = pageSize;
    }
}

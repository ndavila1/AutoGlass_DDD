using MediatR;
using Entity = DDD.Domain.Core.Entities;

namespace DDD.Domain.Queries.Product
{
    public record GetAllProductsQuery(int skip, int take) : IRequest<List<Entity.Product>>
    {
    }
}

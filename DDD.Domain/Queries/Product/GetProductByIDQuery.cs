using Entity = DDD.Domain.Core.Entities;
using MediatR;

namespace DDD.Domain.Queries.Product
{
    public record GetProductByIDQuery(int id) : IRequest<Entity.Product>
    {
    }
}

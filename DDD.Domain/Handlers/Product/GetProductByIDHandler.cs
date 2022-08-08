using MediatR;
using Entity = DDD.Domain.Core.Entities;
using DDD.Domain.Core.Repositories;
using DDD.Domain.Queries.Product;

namespace DDD.Domain.Handlers.Product
{
    public class GetProductByIDHandler : IRequestHandler<GetProductByIDQuery, Entity.Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIDHandler(IProductRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Entity.Product> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetProductById(request.id);
        }
    }
}

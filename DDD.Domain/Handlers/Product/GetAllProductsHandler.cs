using DDD.Domain.Core.Repositories;
using DDD.Domain.Queries.Product;
using MediatR;
using Entity = DDD.Domain.Core.Entities;

namespace DDD.Domain.Handlers.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Entity.Product>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<Entity.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllProducts(request.skip, request.take);
        }
    }
}

using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Application.ViewModel;
using DDD.Domain.Commands.Product;
using DDD.Domain.Queries.Product;
using DDD.Domain.Validations;
using MediatR;

namespace DDD.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<ValidationResult> AddProduct(ProductViewModelInput product)
        {

            var productResult = this._mapper.Map<AddProductCommand>(product);
            return await this._mediator.Send(productResult);


        }

        public async Task<ValidationResult> DeleteProduct(int id)
        {
            return await this._mediator.Send(new DeleteProductCommand(id));
        }


        public async Task<ProductViewModelOutput> GetProductById(int id)
        {
            var result  = await this._mediator.Send(new GetProductByIDQuery(id));
            return this._mapper.Map<ProductViewModelOutput>(result);
        }

        public async Task<ValidationResult> UpdateProduct(int id, ProductViewModelInput product)
        {
            var productResult = this._mapper.Map<UpdateProductCommand>(product);
            productResult.ProductID = id;
            return await this._mediator.Send(productResult);
        }

        public async Task<List<ProductViewModelOutput>> GetAllProducts(int? page)
        {
            const int pageSize = 5;
            var result = await this._mediator.Send(new GetAllProductsQuery((page ?? 0) * pageSize, pageSize));
            return this._mapper.Map<List<ProductViewModelOutput>>(result);
        }
    }
}

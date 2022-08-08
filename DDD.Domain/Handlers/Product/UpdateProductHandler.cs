using AutoMapper;
using DDD.Domain.Commands.Product;
using DDD.Domain.Core.Repositories;
using DDD.Domain.Validations;
using MediatR;
using Entity = DDD.Domain.Core.Entities;


namespace DDD.Domain.Handlers.Product
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ValidationResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }
        public async Task<ValidationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = request.IsValid();
            if (validationResult.IsValid)
            {
                var newProduct = _mapper.Map<Entity.Product>(request);
                var exitingProduct = _repository.GetProductById(newProduct.ProductId);
                if (exitingProduct is null)
                {
                    return new ValidationResult(false, "The product was not found");
                }

                exitingProduct.Update(newProduct.Description, newProduct.State, newProduct.ManufacturingDate, newProduct.ValidityDate, newProduct.Provider);

                _repository.UpdateProduct(exitingProduct);
            }

            return validationResult;
        }
    }
}

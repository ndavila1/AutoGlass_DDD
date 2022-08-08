using DDD.Domain.Commands.Product;
using DDD.Domain.Core.Repositories;
using DDD.Domain.Validations;
using MediatR;

namespace DDD.Domain.Handlers.Product
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ValidationResult>
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var exitingProduct = _repository.GetProductById(request.id);
            if (exitingProduct is null)
            {
                return new ValidationResult(false, "The product was not found");
            }

            exitingProduct.Delete();

            _repository.UpdateProduct(exitingProduct);

            return new ValidationResult(false, "The product was deleted successfully");
        }
    }
}

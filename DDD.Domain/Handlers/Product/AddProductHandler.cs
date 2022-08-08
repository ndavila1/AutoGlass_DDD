using DDD.Domain.Core.Repositories;
using Entity = DDD.Domain.Core.Entities;
using MediatR;
using DDD.Domain.Validations;
using AutoMapper;
using DDD.Domain.Commands.Product;

namespace DDD.Domain.Handlers.Product
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ValidationResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public AddProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<ValidationResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = request.IsValid();
            if (validationResult.IsValid)
            {
                var result = _mapper.Map<Entity.Product>(request);
                _repository.AddProduct(result);
            }

            return validationResult;

        }
    }
}

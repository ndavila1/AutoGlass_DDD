using DDD.Domain.Commands.Product;
using DDD.Domain.Core.Entities;
using DDD.Domain.Validations;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class ProductServiceTest
    {
        [Fact]
        public void SaveProductTest()
        {
            var product = CreateProduct("Hello word", true, DateTime.Now, DateTime.Now.AddDays(5), "1123", "I am a provider", "Phone 123123123");

            var command = new AddProductCommand();

            var validation = new ValidationResult(true, "The product has been created successfully");

            var customerRepositoryMock = new Mock<IMediator>();
            customerRepositoryMock.Setup(x => x.Send(command))
                .Returns(validation);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CustomerViewModel>(customer)).Returns(new CustomerViewModel

            var service = new ProductService()
        }

        private  Product CreateProduct(string description, bool state, DateTime manufacturingDate, DateTime validityDate,
            string? providerId, string? providerdDescription, string? providerPhoneNumber)
        {

            var provider = CreateProvider(providerId, providerdDescription, providerPhoneNumber);
            return new Product(description, state, manufacturingDate, validityDate, provider);
        }

        private  Provider CreateProvider(string? providerId, string? description, string? phoneNumber) =>
            new Provider(providerId, description, phoneNumber);
    }
}

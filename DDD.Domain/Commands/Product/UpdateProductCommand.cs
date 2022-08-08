using DDD.Domain.Validations;
using MediatR;

namespace DDD.Domain.Commands.Product
{
    public class UpdateProductCommand : IRequest<ValidationResult>
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public bool State { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public string? ProviderId { get; set; }
        public string? ProviderDescription { get; set; }
        public string? PhoneNumber { get; set; }

        public UpdateProductCommand()
        {

        }
        public UpdateProductCommand(int productid, string description, bool state, DateTime manufacturingDate, DateTime validityDate,
            string? providerId, string? providerdDescription, string? providerPhoneNumber)
        {
            this.ProductID = productid;
            ProductDescription = description;
            State = state;
            ManufacturingDate = manufacturingDate;
            ValidityDate = validityDate;
            ProviderId = providerId;
            ProviderDescription = providerdDescription;
            PhoneNumber = providerPhoneNumber;
        }

        public ValidationResult IsValid()
        {
            if (ManufacturingDate >= ValidityDate)
            {
                return new ValidationResult(false, "Validity date must be greater than manufacturing date");
            }
            if (string.IsNullOrEmpty(ProductDescription))
            {
                return new ValidationResult(false, "description value must be mandatory");
            }

            return new ValidationResult(true, "The product has been updated successfully");
        }
    }
}

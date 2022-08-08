using System.ComponentModel.DataAnnotations;


namespace DDD.Application.ViewModel
{
    public class ProductViewModelInput
    {
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public bool State { get; set; }
        [Required]
        public DateTime ManufacturingDate { get; set; }
        [Required]
        public DateTime ValidityDate { get; set; }
        public string? ProviderId { get; set; }
        public string? ProviderDescription { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

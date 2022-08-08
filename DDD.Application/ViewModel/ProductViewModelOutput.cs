using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.ViewModel
{
    public class ProductViewModelOutput
    {
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public bool State { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public string? ProviderId { get; set; }
        public string? ProviderDescription { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

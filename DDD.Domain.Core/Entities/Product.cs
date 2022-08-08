using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Core.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Description { get; private set; }
        public bool State { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public DateTime ValidityDate { get; private set; }
        public Provider Provider { get; private set; }

        // Empty constructor for EF
        private Product()
        {

        }

        public Product(string description, bool state, DateTime manufacturingDate, DateTime validityDate, Provider provider)
        {
            this.Description = description;
            this.State = state;
            this.ManufacturingDate = manufacturingDate;
            this.ValidityDate = validityDate;
            this.Provider = provider;
            
        }
        public void Update(string description, bool state, DateTime manufacturingDate, DateTime validityDate, Provider provider)
        {
            this.Description = description;
            this.State = state;
            this.ManufacturingDate = manufacturingDate;
            this.ValidityDate = validityDate;
            this.Provider = provider;
        }

        public void Delete()
        {
            this.State = false;
        }
    }
}

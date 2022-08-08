using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Core.Entities
{
    public class Provider
    {
        public string? ProviderId { get; private set; }
        public string? Description { get; private set; }
        public string? PhoneNumber { get; private set; }

        // Empty constructor for EF
        public Provider()
        {

        }
        public Provider(string? providerId, string? description, string? phoneNumber)
        {
            this.ProviderId = providerId;
            this.Description = description;
            this.PhoneNumber = phoneNumber;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Validations
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string Message { get; private set; }

        public ValidationResult(bool isValid, string message)
        {
            this.IsValid = isValid;
            this.Message = message;
        }
    }
}

using DDD.Domain.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Commands.Product
{
    public record DeleteProductCommand(int id) : IRequest<ValidationResult>
    {
    }
}

using AutoMapper;
using DDD.Application.ViewModel;
using DDD.Domain.Commands.Product;
using DDD.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<ProductViewModelInput, AddProductCommand>();
            CreateMap<ProductViewModelInput, UpdateProductCommand>();
        }
    }
}

using AutoMapper;
using DDD.Domain.Commands.Product;
using DDD.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.AutoMapper
{
    public class CommandToDomainMappingProfile: Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<Product, AddProductCommand>()
                .ForMember(dto => dto.ProductDescription, opt => opt.MapFrom(p => p.Description))
                .ForMember(dto => dto.ProviderId, opt => opt.MapFrom(p => p.Provider.ProviderId))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(p => p.Provider.PhoneNumber))
                .ReverseMap();

            CreateMap<Product, UpdateProductCommand>()
                .ForMember(dto => dto.ProductDescription, opt => opt.MapFrom(p => p.Description))
                .ForMember(dto => dto.ProviderId, opt => opt.MapFrom(p => p.Provider.ProviderId))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(p => p.Provider.PhoneNumber))
                .ReverseMap();


        }
    }
}

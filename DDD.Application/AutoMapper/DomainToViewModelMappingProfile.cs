using DDD.Application.ViewModel;
using DDD.Domain.Core.Entities;
using AutoMapper;

namespace DDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModelOutput>()
                .ForMember(dto => dto.ProductDescription, opt => opt.MapFrom(p => p.Description))
                .ForMember(dto => dto.ProviderId, opt => opt.MapFrom(p => p.Provider.ProviderId))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(p => p.Provider.PhoneNumber))
                .ForMember(dto => dto.ProviderDescription, opt => opt.MapFrom(p => p.Provider.Description));
        }
    }
}

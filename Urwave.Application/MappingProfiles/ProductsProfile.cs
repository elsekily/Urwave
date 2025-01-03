using AutoMapper;
using Urwave.Application.Resources;
using Urwave.Core.Entities;

namespace Urwave.Application.MappingProfiles;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<Product, ProductResource>();

        CreateMap<ProductRequest, Product>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore());
    }
}
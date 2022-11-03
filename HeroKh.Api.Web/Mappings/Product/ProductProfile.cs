using AutoMapper;
using HeroKh.Api.Web.DTOs.Product;

namespace HeroKh.Api.Web.Mappings.Product
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Models.Product>();
            CreateMap<Models.Product, ReadonlyProductDto>()
                .ForMember(m => m.ProductCategorySlug, opt => opt.MapFrom(p => p.ProductCategory!.Slug))
                .ForMember(m => m.ProductCategoryName, opt => opt.MapFrom(p => p.ProductCategory!.Name));
        }
    }
}

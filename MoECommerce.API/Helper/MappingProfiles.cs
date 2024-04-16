using AutoMapper;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Models.Basket;
using MoECommerce.Core.Models.Product;

namespace MoECommerce.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductBrand, BrandTypeDto>();

            CreateMap<ProductType, BrandTypeDto>();

            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=> d.BrandName, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o=> o.MapFrom<PictureUrlResolver>());

            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();

            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Models.Order;

namespace MoECommerce.API.Helper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<ShippingAddress, ShippingAddressDto>().ReverseMap();

            CreateMap<Order, OrderResultDto>()
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.ShippingPrice, opt => opt.MapFrom(src => src.DeliveryMethod.Price)).ReverseMap();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.orderItemProduct.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.orderItemProduct.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.orderItemProduct.PictureUrl))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemResolver>()).ReverseMap();
        }
    }
}

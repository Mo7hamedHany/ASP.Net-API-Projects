using AutoMapper;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Models.Order;
using MoECommerce.Core.Models.Product;

namespace MoECommerce.API.Helper
{
    public class OrderItemResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.orderItemProduct.PictureUrl) ? $"{_configuration["BaseUrl"]}{source.orderItemProduct.PictureUrl}" : string.Empty;
        }
    }
}
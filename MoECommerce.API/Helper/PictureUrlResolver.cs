using AutoMapper;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Models.Product;

namespace MoECommerce.API.Helper
{
    public class PictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.PictureUrl) ? $"{_configuration["BaseUrl"]}{source.PictureUrl}" : string.Empty;
        }
    }
}

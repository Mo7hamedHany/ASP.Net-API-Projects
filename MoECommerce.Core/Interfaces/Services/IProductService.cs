using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.SpecificationParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<PaginatedResultDto<ProductToReturnDto>> GetAllProductsAsync(ProductSpecificationParameters parameters);

        Task<IEnumerable<BrandTypeDto>> GetAllBrandsAsync();

        Task<IEnumerable<BrandTypeDto>> GetAllTypesAsync();

        Task<ProductToReturnDto> GetProductsAsync(int id);
    }
}

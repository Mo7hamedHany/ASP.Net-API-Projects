using AutoMapper;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Interfaces.Repositories;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Core.Models.Product;
using MoECommerce.Core.SpecificationParameters;
using MoECommerce.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BrandTypeDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();

            return  _mapper.Map<IEnumerable<BrandTypeDto>>(brands);

        }

        public async Task<PaginatedResultDto<ProductToReturnDto>> GetAllProductsAsync(ProductSpecificationParameters parameters)
        {
            var specs = new ProductSpecifications(parameters);
            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecsAsync(specs);
            var specsCount = new ProductCountSpecifications(parameters);
            var count = await _unitOfWork.Repository<Product, int>().GetCountWithSpecsAsync(specsCount);
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return new PaginatedResultDto<ProductToReturnDto>
            {
                Data = mappedProducts,
                PageIndex = parameters.PageIndex,
                PageSize = parameters.PageSize,
                Totalount = count
            };
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();

            return _mapper.Map<IEnumerable<BrandTypeDto>>(types);
        }

        public async Task<ProductToReturnDto> GetProductsAsync(int id)
        {
            var specs = new ProductSpecifications(id);
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecsAsync(specs);

            return _mapper.Map<ProductToReturnDto>(product);
        }
    }
}

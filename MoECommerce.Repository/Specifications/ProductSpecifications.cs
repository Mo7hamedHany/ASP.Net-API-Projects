using MoECommerce.Core.Models.Product;
using MoECommerce.Core.Specification;
using MoECommerce.Core.SpecificationParameters;

namespace MoECommerce.Repository.Specifications
{
    public class ProductSpecifications : BaseSpecification<Product>
    {
        public ProductSpecifications(ProductSpecificationParameters parameters)
            : base(product =>
            (!parameters.TypeId.HasValue || parameters.TypeId.Value == product.TypeId) &&
            (!parameters.BrandId.HasValue || parameters.BrandId.Value == product.BrandId) &&
            (string.IsNullOrEmpty(parameters.Search) || product.Name.Contains(parameters.Search)))
        {
            IncludeExpressions.Add(product => product.ProductType);
            IncludeExpressions.Add(product => product.ProductBrand);

            ApplyPagination(parameters.PageSize, parameters.PageIndex);

            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSpecificationEnum.NameAsc:
                        OrderBy = x => x.Name;
                        break;
                    case ProductSpecificationEnum.NameDesc:
                        OrderByDesc = x => x.Name;
                        break;
                    case ProductSpecificationEnum.PriceAsc:
                        OrderBy = x => x.Price;
                        break;
                    case ProductSpecificationEnum.PriceDesc:
                        OrderByDesc = x => x.Price;
                        break;
                    default:
                        OrderBy = x => x.Name;
                        break;
                }
            }
            else
            {
                OrderBy = x => x.Name;
            }
        }

        public ProductSpecifications(int id)
            : base(product => product.Id == id)
        {
            IncludeExpressions.Add(product => product.ProductType);
            IncludeExpressions.Add(product => product.ProductBrand);
        }
    }
}

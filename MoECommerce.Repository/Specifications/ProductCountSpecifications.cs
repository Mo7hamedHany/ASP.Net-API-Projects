using Microsoft.EntityFrameworkCore.Query;
using MoECommerce.Core.Models.Product;
using MoECommerce.Core.Specification;
using MoECommerce.Core.SpecificationParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Repository.Specifications
{
    public class ProductCountSpecifications : BaseSpecification<Product>
    {
        public ProductCountSpecifications(ProductSpecificationParameters parameters)
           : base(product =>
           (!parameters.TypeId.HasValue || parameters.TypeId.Value == product.TypeId) &&
           (!parameters.BrandId.HasValue || parameters.BrandId.Value == product.BrandId) &&
            (string.IsNullOrEmpty(parameters.Search) || product.Name.Contains(parameters.Search)))
        {
            
        }
    }
}

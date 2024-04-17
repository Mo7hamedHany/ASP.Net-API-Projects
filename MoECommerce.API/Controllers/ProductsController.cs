using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoECommerce.API.Errors;
using MoECommerce.API.Helper;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Core.SpecificationParameters;

namespace MoECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpGet]
        [Cash(60)]
        public async Task<ActionResult> GetAllProducts([FromQuery]ProductSpecificationParameters parameters)
        {
            return Ok(await _productService.GetAllProductsAsync(parameters));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int? id)
        {
           // throw new Exception();
            var product = await _productService.GetProductsAsync(id.Value);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404));
        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetAllBrands()
        {
            return Ok(await _productService.GetAllBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetAllTypes()
        {
            return Ok(await _productService.GetAllTypesAsync());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Interfaces.Services;

namespace MoECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> Get(string id)
        {
            var basket = await _basketService.GetBasketAsync(id);

            return basket is null ? NotFound(404) : Ok(basket); 
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> Update(CustomerBasketDto basketDto)
        {
            var basket = await _basketService.UpdateBasketAsync(basketDto);
            return basket is null ? NotFound(404) : Ok(basket);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id) => Ok(await _basketService.DeleteBasketAsync(id));
    }
}

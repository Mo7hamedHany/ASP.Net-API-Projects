using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoECommerce.API.Errors;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Interfaces.Services;

namespace MoECommerce.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<loginDto>> Login(loginDto input)
        {
            var user = await _userService.LoginAsync(input);

            return user is not null ? Ok(user) : Unauthorized(new ApiResponse(401));
        }

        [HttpPost]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto input)
        {

            return Ok( await _userService.RegisterAsync(input)); 
        }
    }
}

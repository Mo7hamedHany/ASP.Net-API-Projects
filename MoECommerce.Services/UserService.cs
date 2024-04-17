using Microsoft.AspNetCore.Identity;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto?> LoginAsync(loginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is not null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password,false);
                if (result.Succeeded)
                {
                    return new UserDto
                    {
                        DisplayName = user.DisplayName,
                        Email = user.Email,
                        Token = _tokenService.GetToken(user)
                    };
                   
                }
                
            }
            return null;
        }

        public async Task<UserDto?> RegisterAsync(RegisterDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is not null) throw new Exception("Email Exists");

            var appuser = new ApplicationUser
            {
                DisplayName = dto.DisplayName,
                Email = dto.Email,
                UserName = dto.DisplayName,
            };

            var result = await _userManager.CreateAsync(appuser , dto.Password);

            if (!result.Succeeded) throw new Exception("Error");
            return new UserDto
            {
                DisplayName = dto.DisplayName,
                Email = dto.Email,
                Token = _tokenService.GetToken(appuser)
            };

        }
    }
}

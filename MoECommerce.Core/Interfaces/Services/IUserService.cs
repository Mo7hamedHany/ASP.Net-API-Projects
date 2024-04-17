using MoECommerce.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> LoginAsync(loginDto? dto);

        Task<UserDto> RegisterAsync(RegisterDto dto);
    }
}

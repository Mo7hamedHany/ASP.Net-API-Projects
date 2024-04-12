using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface ICashService
    {
        Task SetCashResponceAsync(string key, object response, TimeSpan time);

        Task<string?> GetCashResponceAsync(string key);
    }
}

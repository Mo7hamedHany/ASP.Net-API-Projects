using MoECommerce.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface IBasketService
    {
        Task<CustomerBasketDto?> GetBasketAsync(string id);

        Task<CustomerBasketDto?> UpdateBasketAsync(CustomerBasketDto basket);

        Task<bool> DeleteBasketAsync(string id);
    }
}

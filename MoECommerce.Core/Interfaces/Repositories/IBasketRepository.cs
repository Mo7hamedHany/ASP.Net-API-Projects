using MoECommerce.Core.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetCustomerBasketAsync(string id);

        Task<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket);

        Task<bool> DeleteCustomerBasketAsync(string id);
    }
}

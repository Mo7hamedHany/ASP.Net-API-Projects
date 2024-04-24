using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<DeliveryMethods>> GetDeliveryMethodsAsync();

        public Task<OrderResultDto> CreateOrderAsync(OrderDto input);

        public Task<OrderResultDto> GetOrderAsync(Guid id, string email );

        public Task<IEnumerable<OrderResultDto>> GetAllOrdersAsync(string email);
    }
}

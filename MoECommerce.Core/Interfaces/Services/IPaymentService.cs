using MoECommerce.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<CustomerBasketDto> CreateOrUpdatePaymentIntentForExistingOrder(CustomerBasketDto basket);

        Task<CustomerBasketDto> CreateOrUpdatePaymentIntentForNewOrder(string? basketId);

        Task<OrderResultDto> UpdatePaymentStatusFailed(string paymentIntentId);

        Task<OrderResultDto> UpdatePaymentStatusSuceeded(string paymentIntentId);
    }
}

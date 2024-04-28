using MoECommerce.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.DataTransferObjects
{
    public class OrderDto
    {
        public string BasketId { get; set; }

        public string BuyerEmail { get; set; }

        public int? DeliveryMethodId { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }


    }
}

using MoECommerce.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.DataTransferObjects
{
    public class OrderResultDto
    {
        public Guid Id { get; set; }

        public string BuyerEmail { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ShippingAddressDto ShippingAddress { get; set; }

        public string DeliveryMethod { get; set; }

        public IEnumerable<OrderItemDto> OrderItems { get; set; }

        public PaymentStatus paymentStatus { get; set; } = PaymentStatus.Pending;

        public decimal SubTotal { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Total { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? BasketId { get; set; }
    }
}

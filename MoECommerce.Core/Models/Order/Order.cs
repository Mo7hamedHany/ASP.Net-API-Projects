using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Models.Order
{
    public class Order : BaseModel<Guid>
    {
        public string BuyerEmail { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ShippingAddress ShippingAddress { get; set; }

        public DeliveryMethods DeliveryMethod { get; set; }

        public int? DeliveryMethodId { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }

        public PaymentStatus paymentStatus { get; set; } = PaymentStatus.Pending;

        public decimal SubTotal { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? BasketId { get; set; }

        public decimal Total() => SubTotal + DeliveryMethod.Price;
    }
}

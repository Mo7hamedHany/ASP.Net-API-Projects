using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Models.Order
{
    public class OrderItem : BaseModel<Guid>
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public OrderItemProduct orderItemProduct { get; set; }
    }
}

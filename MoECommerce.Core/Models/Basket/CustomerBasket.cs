using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Models.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; }

        public int? DeleviryMethod { get; set; }

        public decimal ShippingPrice { get; set; }

        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}

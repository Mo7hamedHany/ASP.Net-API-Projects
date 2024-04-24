using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Models.Order
{
    public class OrderItemProduct
    {
        public int ProductId { get; set;}

        public string ProductName { get; set;}

        public string PictureUrl { get; set; }
    }
}

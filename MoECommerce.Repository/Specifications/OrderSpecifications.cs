using MoECommerce.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Repository.Specifications
{
    public class OrderSpecifications : BaseSpecification<Order>
    {
        public OrderSpecifications(string email) 
            : base(order => order.BuyerEmail ==email)
        {
            IncludeExpressions.Add(order => order.DeliveryMethod);
            IncludeExpressions.Add(order => order.OrderItems);

        }

        public OrderSpecifications(Guid id, string email)
    : base(order => order.BuyerEmail == email && order.Id == id)
        {
            IncludeExpressions.Add(order => order.DeliveryMethod);
            IncludeExpressions.Add(order => order.OrderItems);

        }
    }
}

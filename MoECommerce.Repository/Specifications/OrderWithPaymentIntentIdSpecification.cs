using MoECommerce.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Repository.Specifications
{
    public class OrderWithPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentIdSpecification(string paymentIntentId) 
            : base(order => order.PaymentIntentId == paymentIntentId)
        {
            IncludeExpressions.Add(del => del.DeliveryMethod);
        }
    }
}

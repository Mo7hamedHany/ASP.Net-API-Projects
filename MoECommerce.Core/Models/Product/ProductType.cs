using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Models.Product
{
    public class ProductType : BaseModel<int>
    {
        public string Name { get; set; }
    }
}

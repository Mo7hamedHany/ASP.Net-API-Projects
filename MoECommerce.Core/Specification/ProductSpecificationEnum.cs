using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoECommerce.Core.Specification
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductSpecificationEnum
    {
        NameAsc, NameDesc, PriceAsc, PriceDesc,
    }
}

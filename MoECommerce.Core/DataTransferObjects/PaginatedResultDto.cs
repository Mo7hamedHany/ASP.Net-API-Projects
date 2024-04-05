using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.DataTransferObjects
{
    public class PaginatedResultDto<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Totalount { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces
{
    public interface ISpecification<T>
    {
        public Expression<Func<T,bool>> Criteria { get; }
        public List<Expression<Func<T,object>>> IncludeExpressions { get; }
        public Expression<Func<T, object>> OrderBy { get; }
        public Expression<Func<T, object>> OrderByDesc { get; }
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginated { get; }
    }
}

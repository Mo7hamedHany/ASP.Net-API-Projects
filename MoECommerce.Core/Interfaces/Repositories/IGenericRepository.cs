using MoECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity , TKey> where TEntity : BaseModel<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecification<TEntity> specification);

        Task<int> GetCountWithSpecsAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetAsync(TKey id);

        Task<TEntity> GetWithSpecsAsync(ISpecification<TEntity> specification);

        Task AddAsunc(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}

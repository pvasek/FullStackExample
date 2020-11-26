using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackExample.Services
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);
        Task<IList<TEntity>> GetAllAsync();
        Task SaveAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}

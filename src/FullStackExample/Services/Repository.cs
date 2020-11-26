using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackExample.Services
{

    public class InMemoryTaskRepository<TEntity> : IRepository<TEntity> where TEntity: Entities.IEntity
    {
        private Dictionary<Guid, TEntity> _items = new Dictionary<Guid, TEntity>();
        private object _syncRoot = new object();

        public Task<IList<TEntity>> GetAllAsync()
        {
            lock (_syncRoot)
            {
                return Task.FromResult((IList<TEntity>)_items.Values.ToList());
            }
        }

        public Task<TEntity> GetAsync(Guid id)
        {
            lock (_syncRoot)
            {
                _items.TryGetValue(id, out var item);
                return Task.FromResult(item);
            }
        }

        public Task SaveAsync(TEntity entity)
        {
            lock (_syncRoot)
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                // this is just a fake, normaly we should at least copy it in this case
                if (_items.ContainsKey(entity.Id))
                {
                    _items[entity.Id] = entity;
                }
                else
                {
                    _items.Add(entity.Id, entity);
                }
            }
            return Task.CompletedTask;
        }

        public Task RemoveAsync(TEntity entity)
        {
            lock (_syncRoot)
            {
                _items.Remove(entity.Id);
            }
            return Task.CompletedTask;
        }
    }
}

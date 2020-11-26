
using System.Threading.Tasks;

namespace FullStackExample.Validators
{
    public interface IValidator<TEntity> where TEntity: Entities.IEntity
    {
        Task<bool> ValidateAsync(TEntity entity);
    }
}

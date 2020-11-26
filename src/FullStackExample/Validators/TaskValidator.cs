using FullStackExample.Services;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackExample.Validators
{
    public class TaskValidator : IValidator<Entities.Task>
    {
        private readonly IRepository<Entities.Task> _repository;

        public TaskValidator(IRepository<Entities.Task> repository)
        {
            _repository = repository;
        }

        public async Task<bool> ValidateAsync(Entities.Task entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return false;
            }

            var items = await _repository.GetAllAsync();
            return items.All(i => i.Id == entity.Id || i.Name != entity.Name);
        }
    }
}

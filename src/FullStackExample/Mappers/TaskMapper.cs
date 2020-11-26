namespace FullStackExample.Mappers
{
    public static class TaskMapper
    {
        public static Dtos.Task ToDto(Entities.Task entity)
        {
            return new Dtos.Task
            {
                Id = entity.Id,
                Name = entity.Name,
                Priority = entity.Priority,
                Status = (Dtos.TaskStatus) entity.Status,
            };
        }

        public static void UpdateEntity(Dtos.Task dto, Entities.Task entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Priority = dto.Priority;
            entity.Status = (Entities.TaskStatus) dto.Status;
        }
    }
}

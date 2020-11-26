using System;

namespace FullStackExample.Entities
{

    public class Task: IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
    }
}

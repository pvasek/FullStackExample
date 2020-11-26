﻿using System;

namespace FullStackExample.Dtos
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
    }
}

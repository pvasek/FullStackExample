using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackExample.Dtos
{
    public class Task
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
    }
}

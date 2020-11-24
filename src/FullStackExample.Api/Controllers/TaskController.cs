using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using FullStackExample.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FullStackExample.Api.Controllers
{
    [ApiController]
    [Route("api/v1/tasks")]
    public class TaskController: ControllerBase
    {
        [HttpGet]
        public IList<Dtos.Task> GetAll()
        {
            return new List<Dtos.Task>
            {
                new Dtos.Task { Name = "task1" },
                new Dtos.Task { Name = "task2" },
            };
        }
    }
}

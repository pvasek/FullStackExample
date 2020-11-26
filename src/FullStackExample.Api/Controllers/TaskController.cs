using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackExample.Mappers;
using FullStackExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStackExample.Api.Controllers
{
    [ApiController]
    [Route("api/v1/tasks")]
    public class TaskController: ControllerBase
    {
        private readonly IRepository<Entities.Task> _repository;
        
        public TaskController(IRepository<Entities.Task> repository)
        {
           _repository = repository;
        }

        [HttpGet]
        public async Task<IList<Dtos.Task>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return entities
                .Select(TaskMapper.ToDto)
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.Task>> Get(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return TaskMapper.ToDto(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Dtos.Task>> Create([FromBody] Dtos.Task dto)
        {
            var entity = new Entities.Task();
            TaskMapper.UpdateEntity(dto, entity);
            await _repository.SaveAsync(entity);
            dto = TaskMapper.ToDto(entity);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] Dtos.Task dto)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            TaskMapper.UpdateEntity(dto, entity);
            await _repository.SaveAsync(entity);
            dto = TaskMapper.ToDto(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _repository.RemoveAsync(entity);
            return Ok();
        }
    }
}

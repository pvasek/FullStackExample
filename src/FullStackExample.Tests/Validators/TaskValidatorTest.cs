using FullStackExample.Services;
using FullStackExample.Validators;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FullStackExample.Tests
{
    public class TaskValidatorTest
    {
        [Fact]
        public async Task Should_pass_if_name_is_unique()
        {
            var mock = CreateRepository("name1", "name2");
            var target = new TaskValidator(mock);
            var result = await target.ValidateAsync(new Entities.Task { Name = "name3" });
            Assert.True(result);
        }

        [Fact]
        public async Task Should_fail_if_name_is_not_unique()
        {
            var mock = CreateRepository("name1", "name2");
            var target = new TaskValidator(mock);
            var result = await target.ValidateAsync(new Entities.Task { Name = "name2" });
            Assert.False(result);
        }

        [Fact]
        public async Task Should_fail_if_name_is_empty()
        {
            var mock = CreateRepository("name1", "name2");
            var target = new TaskValidator(mock);
            var result = await target.ValidateAsync(new Entities.Task { Name = "" });
            Assert.False(result);
        }

        private static IRepository<Entities.Task> CreateRepository(params string[] names)
        {
            var items = names.Select(i => new Entities.Task
            {
                Id = Guid.NewGuid(),
                Name = i,
                Status = Entities.TaskStatus.NotStarted,
                Priority = 1,
            })
            .ToList();

            var mock = new Mock<IRepository<Entities.Task>>();
            mock.Setup(i => i.GetAllAsync()).Returns(Task.FromResult((IList<Entities.Task>)items));
            return mock.Object;
        }

    }
}

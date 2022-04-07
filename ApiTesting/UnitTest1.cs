using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Contract;
using Api.Service;
using Moq;
using ToDoApi;
using ToDoApi.Data;
using ToDoApi.Models;
using Xunit;

namespace ApiTesting
{
    public class TodoServiceTest : IDisposable
    {
        private readonly TodoItemsContext _context;
        public TodoServiceTest()
        {
            _context = MockDatabase.CreateDB(Guid.NewGuid().ToString());
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public async Task GetTodoItems_Empty()
        {
            //var context = MockDatabase.CreateDB("Empty");
            var service = new TodoService(_context);

            var result = await service.GetTodoItems();

            Assert.Empty(result);
            //Assert.Equal(0, result.Count);
        }
        [Fact]
        public async Task GetTodoItems_HasValue()
        {
            _context.TodoItems.Add(new TodoItem { Name = "test 1" });
            _context.SaveChanges();
            var service = new TodoService(_context);

            var result = await service.GetTodoItems();

            //Assert.Empty(result);
            //Assert.Equal(1, result.Count);
            Assert.NotEmpty(result);
            Assert.Equal("test 1", result.First().Name);
        }

        [Fact]
        public async Task TodoControllerTest()
        {
            var service = new Mock<ITodoService>();
            service.Setup(s => s.GetTodoItem(3)).ReturnsAsync(new TodoItemContract());
            service.Setup(s => s.GetTodoItem(1)).ReturnsAsync(new TodoItemContract());
            var controller = new TodoItemsController(service.Object);

            var result = await controller.GetTodoItem(3);

            Assert.NotNull(result.Value);
        }
    }
}

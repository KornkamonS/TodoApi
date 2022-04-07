using Api.Contract;
using Api.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using ToDoApi;
using ToDoApi.Data;
using Xunit;

namespace ApiTest
{
    public class TodoItemControllerTest : IDisposable
    { 
        private readonly TodoItemsContext _context;
        public TodoItemControllerTest()
        {
            _context = DbContextMocker.CreateTestingDatabase(Guid.NewGuid().ToString());
        }
        public void Dispose()
        {
            _context.Dispose(); 
        }

        [Fact]
        public async Task Get_AllToDoItem_Success()
        {
            // Prepare
            DbContextMocker.SeedTestSuccess(_context);
            var service = new TodoService(_context);
            var controller = new TodoItemsController(service);
            
            // Act
            var response = await controller.GetTodoItem(1);
            
            // Assert
            Assert.Equal(1, response.Value.Id);
        }

        [Fact]
        public async Task Get_AllToDoItem_Success_2()
        {
            // Prepare
            var context = DbContextMocker.CreateTestingDatabase(Guid.NewGuid().ToString());
            DbContextMocker.SeedTestSuccess(context);
            var service = new TodoService(context);
            var controller = new TodoItemsController(service);

            // Act
            var response = await controller.GetTodoItem(1);
            
            // Assert
            Assert.Equal(1, response.Value.Id);
        }

        [Fact]
        public async Task Get_ToDoItems_NotFound()
        {
            // Prepare
            var moq = new Mock<ITodoService>();
            moq.Setup(_ => _.GetTodoItem(It.IsAny<int>())).ReturnsAsync((TodoItemContract)null);
            var controller = new TodoItemsController(moq.Object);
            
            // Act
            var response = await controller.GetTodoItem(2);
            
            // Assert
            Assert.IsType<NotFoundResult>(response.Result);
        }
    }
}

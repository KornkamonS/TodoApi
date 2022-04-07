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
    public class TodoItemServiceTest : IDisposable
    { 
        private readonly TodoItemsContext _context;
        private readonly ITodoService _testService;
        public TodoItemServiceTest()
        {
            _context = DbContextMocker.CreateTestingDatabase(Guid.NewGuid().ToString());
            _testService = new TodoService(_context);
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
            
            // Act
            var todoItem = await _testService.GetTodoItem(1);
            
            // Assert
            Assert.Equal(1, todoItem.Id);
        } 

        [Fact]
        public async Task Get_ToDoItems_NotFound()
        {  
            // Act
            var result = await _testService.GetTodoItem(2);

            // Assert
            Assert.Null(result);
        }
    }
}

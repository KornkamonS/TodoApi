using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI;
using TodoAPI.Data;
using Xunit;

namespace TestAPI
{
    public class ApiTesting
    {
        public class ToDoControllerTest
        {
            [Fact]
            public async Task Get_AllToDoItem_Success()
            {
                var dbContext = DbContextMocker.CreateTestingDatabase(nameof(Get_AllToDoItem_Success));
                var controller = new TodoItemsController(dbContext);
                var response = await controller.GetTodoItems(1);
                dbContext.Dispose();
                //Assert.Equal(response.Value, new List<TodoItems>() { });
                Assert.Equal(1, response.Value.Id);
            }

            [Fact]
            public async Task Get_ToDoItems_NotFound()
            {
                var dbContext = DbContextMocker.CreateTestingDatabase(nameof(Get_ToDoItems_NotFound));
                var controller = new TodoItemsController(dbContext);
                var response = await controller.GetTodoItems(2);
                dbContext.Dispose();
                Assert.IsType<NotFoundResult>(response.Result);
            }

        }
    }
}

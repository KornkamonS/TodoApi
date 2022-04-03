
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ApiTest
{
    public static class DbContextMocker
    {
        public static void SeedTestSuccess(this TodoItemsContext dbContext)
        {
            dbContext.TodoItems.Add(new TodoItem
            {
                Id = 1,
                Name = "A"
            });
            dbContext.SaveChanges();
        }
        public static void SeedTestNotFound(this TodoItemsContext dbContext)
        {
            dbContext.TodoItems.Add(new TodoItem
            {
                Id = 1,
                Name = "A"
            });
            dbContext.SaveChanges();
        }
        public static TodoItemsContext CreateTestingDatabase(string dbName)
        {
            var options = new DbContextOptionsBuilder<TodoItemsContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new TodoItemsContext(options);
            return dbContext;
        }
    }
}

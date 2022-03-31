using Microsoft.EntityFrameworkCore;
using TodoAPI.Data; 

namespace TestAPI
{
    public static class DbContextMocker
    {
        public static void Seed(this ToDoItemsContext dbContext)
        { 
            dbContext.TodoItems.Add(new TodoItems
            {
                Id = 1,
                Name = "A"
            });
            dbContext.SaveChanges();
        }

        public static ToDoItemsContext CreateTestingDatabase(string dbName)
        { 
            var options = new DbContextOptionsBuilder<ToDoItemsContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
             
            var dbContext = new ToDoItemsContext(options); 
            dbContext.Seed();

            return dbContext;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;

namespace ApiTesting
{
    public static class MockDatabase
    {
        public static TodoItemsContext CreateDB(string dbName)
        {

            var options = new DbContextOptionsBuilder<TodoItemsContext>()
                           .UseInMemoryDatabase(databaseName: dbName)
                           .Options;

            var dbContext = new TodoItemsContext(options);
            return dbContext;
        }
    }
}

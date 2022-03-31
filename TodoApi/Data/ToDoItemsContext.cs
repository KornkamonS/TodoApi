using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data
{
    public class ToDoItemsContext : DbContext
    {
        public ToDoItemsContext (DbContextOptions<ToDoItemsContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItems> TodoItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class TodoItemsContext : IdentityDbContext<User, Role, int>
    {
        public TodoItemsContext() { }
        public TodoItemsContext(DbContextOptions<TodoItemsContext> options)
            : base(options)
        {
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            //
            //builder.Entity<User>()
            //    .HasIndex(s => s.UserName)
            //    .IsUnique();
        }
    }
}

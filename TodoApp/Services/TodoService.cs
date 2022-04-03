using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Contract;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace Api.Service
{
    public class TodoService : ITodoService
    {

        private readonly TodoItemsContext _context;
        public TodoService(TodoItemsContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItemContract>> GetTodoItems()
        {
            var list = await _context.TodoItems.ToListAsync();
            return list.Select(a => new TodoItemContract()
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
        }

        public async Task<TodoItemContract> GetTodoItem(int id)
        {
            var todoItems = await _context.TodoItems.FindAsync(id);

            if (todoItems == null)
            {
                return null;
            }

            return new TodoItemContract() { Id = todoItems.Id, Name = todoItems.Name };
        }

        public async Task<TodoItemContract> UpdateItem(int id, TodoItemContract contract)
        {
            var todo = _context.TodoItems.First(a => a.Id == id);
            todo.Id = id;
            todo.Name = contract.Name;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return contract;
        }
        public async Task<TodoItemContract> CreateItem(TodoItemContract contract)
        {
            var todo = new TodoItem()
            {
                Name = contract.Name
            };
            try
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return contract;
        }

        public async Task<TodoItemContract> DeleteItem(int id)
        {
            var todo = _context.TodoItems.Find(id);
            try
            {
                _context.Remove(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return new TodoItemContract()
            {
                Id = todo.Id,
                Name = todo.Name
            };
        }
    }
}

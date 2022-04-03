using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Contract;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace Api.Service
{
    public class UserService : IUserService
    {

        private readonly TodoItemsContext _context;
        public UserService(TodoItemsContext context)
        {
            _context = context;
        }

    }
}

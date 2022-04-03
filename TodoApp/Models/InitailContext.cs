using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDoApi.Data;

namespace Api.Models
{

    public partial class InitailContext 
    {
        private readonly TodoItemsContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public InitailContext(TodoItemsContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Seed core immutable/master that consistent across every database in locations and cloud.
        /// </summary>
        /// <returns></returns>
        public virtual async Task SeedRoleAsync()
        { 
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new Role() { Name = UserRoles.Admin });
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new Role() { Name = UserRoles.User });
              
        }
    }
}
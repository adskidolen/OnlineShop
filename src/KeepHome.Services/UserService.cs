using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Data;
using KeepHome.Models;
using KeepHome.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace KeepHome.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<KeepHomeUser> userManager;
        
        public UserService(UserManager<KeepHomeUser> userManager)
        {
            this.userManager = userManager;
        }

        public KeepHomeUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }
    }
}

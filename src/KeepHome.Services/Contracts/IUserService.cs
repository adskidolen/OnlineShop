using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;

namespace KeepHome.Services.Contracts
{
    public interface IUserService
    {
        KeepHomeUser GetUserByUsername(string username);
    }
}

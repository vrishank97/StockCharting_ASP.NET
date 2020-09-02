﻿using StockMarket.AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AccountAPI.Repositories
{
    public interface IAccountRepository
    {
        void AddUser(User item);
        User Validate(string uname, string pwd);
        void DeleteUser(long id);
        List<User> GetAllUsers();
        User GetUser(long id);
        User UpdateUser(User user);
    }
}

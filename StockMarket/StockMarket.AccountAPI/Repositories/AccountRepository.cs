﻿using StockMarket.AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AccountAPI.DBAccess;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace StockMarket.AccountAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private StockDBContext context;
        public AccountRepository(StockDBContext context)
        {
            this.context = context;
        }
        public void AddUser(User item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public void DeleteUser(long id)
        {
            User user = GetUser(id);
            context.Users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(long id)
        {
            return context.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User Validate(string uname, string pwd)
        {
            User user = context.Users.SingleOrDefault(i => i.Username == uname && i.Password == pwd);
            return user;
           
        }
    }
}

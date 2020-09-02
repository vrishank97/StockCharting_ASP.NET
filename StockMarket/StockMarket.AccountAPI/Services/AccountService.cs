using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AccountAPI.Repositories;
using StockMarket.AccountAPI.Models;
namespace StockMarket.AccountAPI.Services
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository repo)
        {
            accountRepository = repo;
        }

        public void AddUser(User item)
        {
            accountRepository.AddUser(item);
        }

        public void DeleteUser(long id)
        {
            accountRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return accountRepository.GetAllUsers();
        }

        public User GetUser(long id)
        {
            return accountRepository.GetUser(id);
        }

        public User UpdateUser(User user)
        {
            return accountRepository.UpdateUser(user);
        }

        public User Validate(string uname, string pwd)
        {
            return accountRepository.Validate(uname, pwd);
        }
    }
}

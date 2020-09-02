using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository repo)
        {
            userRepository = repo;
        }

        public List<Company> GetAllCompanies()
        {
            return userRepository.GetCompanies();
        }

        public Company GetCompany(string id)
        {
            return userRepository.GetCompany(id);
        }

        public List<IPODetails> GetIPOS()
        {
            return userRepository.GetIPOS();
        }

        public List<StockPrice> GetStockPrices(string companyCode, DateTime Start, DateTime End)
        {
            return userRepository.GetHistorical(companyCode, Start, End);
        }
    }
}

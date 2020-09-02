using StockMarket.UserAPI.DBAccess;
using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockDBContext context;

        public UserRepository(StockDBContext context)
        {
            this.context = context;
        }

        public List<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }

        public Company GetCompany(string id)
        {
            return context.Companies.Find(id);
        }

        public List<StockPrice> GetHistorical(string companyCode, DateTime start, DateTime end)
        {
            return context.StockPrices.Where(prices => prices.CompanyCode == companyCode && prices.Datetime > start && prices.Datetime < end).ToList();
        }

        public List<IPODetails> GetIPOS()
        {
            return context.IPODetails.ToList();
        }
    }
}

using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    public interface IUserService
    {
        public Company GetCompany(string id);
        public List<Company> GetAllCompanies();
        public List<IPODetails> GetIPOS();
        public List<StockPrice> GetStockPrices(string companyCode, DateTime Start, DateTime End);
    }
}

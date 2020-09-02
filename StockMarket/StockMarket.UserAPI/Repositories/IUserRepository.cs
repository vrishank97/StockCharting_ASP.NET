using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Repositories
{
    public interface IUserRepository
    {
        List<Company> GetCompanies();
        Company GetCompany(string id);
        List<IPODetails> GetIPOS();
        List<StockPrice> GetHistorical(string companyCode, DateTime start, DateTime end);
    }
}

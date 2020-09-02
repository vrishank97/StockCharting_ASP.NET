using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public interface IAdminRepository
    {
        public void AddCompany(Company company);
        List<Company> GetAll();
        void UpdateIPO(IPODetails IPO);
        void UpdateCompany(Company company);
        Company GetCompanybyID(string id);
        void AddIPO(IPODetails IPO);
        void DeleteCompany(string id);
        void DeleteIPO(string id);
        List<IPODetails> GetAllIPOS();
    }
}

using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public interface IAdminService
    {
        public Company GetCompany(string id);
        public void UpdateCompany(Company company);
        public void AddCompany(Company company);
        public void DeleteCompany(string id);
        public void DeleteIPO(string id);
        public void AddIPO(IPODetails IPO);
        public void UpdateIPO(IPODetails IPO);
        public List<DateTime> GetMissingDates(string CompanyCode, DateTime Start, DateTime End);
        public List<Company> GetAllCompanies();
        public List<IPODetails> GetAllIPOS();
    }
}

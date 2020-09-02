using StockMarket.AdminAPI.DBAccess;
using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly StockDBContext context;

        public AdminRepository(StockDBContext context)
        {
            this.context = context;
        }
        public void AddCompany(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();
        }

        public void AddIPO(IPODetails IPO)
        {
            context.IPODetails.Add(IPO);
            context.SaveChanges();
        }

        public void DeleteCompany(string id)
        {
            context.Companies.Remove(context.Companies.Find(id));
            context.SaveChanges();
        }

        public void DeleteIPO(string id)
        {
            context.IPODetails.Remove(context.IPODetails.Find(id));
        }

        public List<Company> GetAll()
        {
            return context.Companies.ToList();
        }

        public List<IPODetails> GetAllIPOS()
        {
            return context.IPODetails.ToList();
        }

        public Company GetCompanybyID(string id)
        {
            return context.Companies.Find(id);
        }

        public void UpdateCompany(Company company)
        {
            context.Companies.Update(company);
            context.SaveChanges();
        }

        public void UpdateIPO(IPODetails IPO)
        {
            context.IPODetails.Update(IPO);
            context.SaveChanges();
        }
    }
}

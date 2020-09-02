using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository repo)
        {
            adminRepository = repo;
        }
        public void AddCompany(Company company)
        {
            adminRepository.AddCompany(company);
        }

        public void AddIPO(IPODetails IPO)
        {
            adminRepository.AddIPO(IPO);
        }

        public void DeleteCompany(string id)
        {
            adminRepository.DeleteCompany(id);
        }

        public void DeleteIPO(string id)
        {
            adminRepository.DeleteIPO(id);
        }

        public List<Company> GetAllCompanies()
        {
            return adminRepository.GetAll();
        }

        public List<IPODetails> GetAllIPOS()
        {
            return adminRepository.GetAllIPOS();
        }

        public Company GetCompany(string id)
        {
            return adminRepository.GetCompanybyID(id);
        }

        public List<DateTime> GetMissingDates(string CompanyCode, DateTime Start, DateTime End)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company company)
        {
            adminRepository.UpdateCompany(company);
        }

        public void UpdateIPO(IPODetails IPO)
        {
            adminRepository.UpdateIPO(IPO);
        }
    }
}

using StockMarket.ExcelAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.ExcelAPI.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IExcelRepository excelRepository;

        public ExcelService(IExcelRepository repo)
        {
            excelRepository = repo;
        }
    }
}

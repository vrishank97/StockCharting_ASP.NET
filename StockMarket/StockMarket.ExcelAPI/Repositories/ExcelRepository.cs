using StockMarket.ExcelAPI.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.ExcelAPI.Repositories
{
    public class ExcelRepository : IExcelRepository
    {
        private readonly StockDBContext context;

        public ExcelRepository(StockDBContext context)
        {
            this.context = context;
        }
    }
}

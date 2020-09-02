using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using StockMarket.ExcelAPI.Models;
using StockMarket.ExcelAPI.Services;

namespace StockMarket.ExcelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService service;

        public ExcelController(IExcelService service)
        {
            this.service = service;
        }

        [HttpGet]

        [Route("ImportStock/{*filePath}")]

        public IList<StockPrice> ImportStock(string filename)

        {

            string filePath = @"D:\IIHT\Client-1\Batch2\PHASE3\Upload\" + filename;
            FileInfo file = new FileInfo(filePath);

            string fileName = file.Name;

            using (ExcelPackage package = new ExcelPackage(file))

            {

                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];

                int totalRows = workSheet.Dimension.Rows;



                List<StockPrice> stockPrices = new List<StockPrice>();



                for (int i = 2; i <= totalRows; i++)

                {

                    stockPrices.Add(new StockPrice

                    {

                        CompanyCode = workSheet.Cells[i, 1].Value.ToString().Trim(),

                        StockExchange = workSheet.Cells[i, 2].Value.ToString().Trim(),

                        CurrentPrice = double.Parse(workSheet.Cells[i, 3].Value.ToString().Trim()),

                        Date = DateTime.Parse(workSheet.Cells[i, 4].Value.ToString().Trim()),

                        Time = workSheet.Cells[i, 5].Value.ToString(),

                    });

                }



                _db.StockPrice.AddRange(stockPrices);

                _db.SaveChanges();



                return stockPrices;

            }

        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using StockMarket.ExcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.ExcelAPI.DBAccess
{
    public class StockDBContext : DbContext
    {
        //Entity Set
        public DbSet<StockPrice> StockPrices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=StockMarketDB;User ID=sa;Password=pass@word1");
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=StockMarket22;User ID=sa;Password=pass@word1;");
        }
    }
}

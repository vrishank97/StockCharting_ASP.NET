using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [Required]
        [StringLength(15)]
        public string CompanyCode { get; set; }
        [Required]
        [StringLength(30)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(30)]
        public string Turnover { get; set; }
        [Required]
        [StringLength(30)]
        public string CEO { get; set; }
        public IEnumerable<StockPrice> StockPrices { get; set; }
    }
}
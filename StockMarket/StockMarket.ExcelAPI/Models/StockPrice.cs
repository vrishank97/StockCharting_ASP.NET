using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.ExcelAPI.Models
{
    [Table("StockPrice")]
    public class StockPrice
    {
        [Key]
        public int RowId { get; set; }
        [ForeignKey("Company")]
        [Required]
        [StringLength(15)]
        public string CompanyCode { get; set; }
        [Required]
        public double CurrPrice { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Datetime { get; set; }

        public Company Company { get; set; }
    }
}

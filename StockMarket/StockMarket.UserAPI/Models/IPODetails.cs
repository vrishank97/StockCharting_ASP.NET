using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Models
{
    [Table("IPODetails")]
    public class IPODetails
    {
        [Key]
        public int IPOId { get; set; }
        [ForeignKey("Company")]
        [Required]
        [StringLength(15)]
        public string CompanyCode { get; set; }
        [Required]
        [StringLength(15)]
        public string StockExchange { get; set; }
        [Required]
        public double SharePrice { get; set; }
        [Required]
        public long Shares { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Datetime { get; set; }

        public Company Company { get; set; }
    }
}

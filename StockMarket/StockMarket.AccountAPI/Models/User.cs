using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AccountAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [StringLength(32)]
        public string Username { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string UserType { get; set; }
        [Required]
        [StringLength(32)]
        public string Email { get; set; }
        [Required]
        [StringLength(32)]
        public string Mobile { get; set; }
        [StringLength(32)]
        public string Confirmed { get; set; }
    }
}

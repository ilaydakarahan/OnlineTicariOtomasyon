using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
        public DateTime Date { get; set; }
        public int Custom { get; set; } //Adet
        public decimal Price { get; set; }
        public decimal TotalAmount{ get; set; }

        public Product Product { get; set; }
        public Employee Employee { get; set; }
        public Current Current { get; set; }
    }
}
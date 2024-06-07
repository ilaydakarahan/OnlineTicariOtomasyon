using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }   //Marka
        public short Stock { get; set; }    //Stok
        public decimal PurchasePrice { get; set; }  //Alış fiyat
        public decimal SalePrice { get; set; }  //Satış fiyat
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }  //Bir ürünün tek kategorisi olabilir

        public ICollection<Sales> Salees { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public decimal Quantity { get; set; }   //Miktar
        public decimal UnitPrice { get; set; }  //Birim fiyat
        public decimal TotalAmount { get; set; }    //Toplam tutar
        public Invoice Invoice { get; set; }    //Bir fatura kaleminin bir faturası olur.
    }
}
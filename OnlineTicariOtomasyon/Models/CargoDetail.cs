using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Staff { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Recipient { get; set; }
        public DateTime CargoDate { get; set; }
    }
}
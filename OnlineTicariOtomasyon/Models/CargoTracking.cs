using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Decription { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingNo { get; set; }
        public DateTime TrackingDate { get; set; }

    }
}
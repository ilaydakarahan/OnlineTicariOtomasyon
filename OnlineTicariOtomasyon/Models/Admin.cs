﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Password { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Authority { get; set; }
    }
}
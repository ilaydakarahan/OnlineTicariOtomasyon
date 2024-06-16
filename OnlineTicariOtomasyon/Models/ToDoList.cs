using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class ToDoList
    {
        [Key]
        public int ToDoId { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ImageUrl { get; set; }
        public ICollection<Sales> Salees { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCWithEFCF4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int _Class { get; set; }
        public string Division { get; set; }
        [MaxLength(1)]
        [Column(TypeName = "Varchar")]
        public string Section { get; set; }
    }
}
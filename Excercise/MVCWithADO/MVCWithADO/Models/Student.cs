using System.ComponentModel.DataAnnotations;

namespace MVCWithADO.Models
{
    public class Student
    {
        [Display(Name ="Student ID")]
        public int SId { get; set; }
        public string SName { get; set; }
        public int? Class {  get; set; }
        public decimal? Fees { get; set; }
        public string Photo {  get; set; }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCWithLinq3.Models
{
    public class EmpDept
    {
        public int EId { get; set; }
        public string EName { get; set; }
        public string Job  { get; set; }
        public decimal? Salary { get; set; }
        public int Did { get; set; }
        public string DName { get; set; }
        public string DLocation { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}
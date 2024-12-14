using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithEFCF4.Models;

namespace MVCWithEFCF4.Controllers
{    
    public class StudentController : Controller
    {
        SchoolDBContext dc = new SchoolDBContext();
        public ActionResult Index()
        {
            Student s1 = new Student() { Name = "Mahesh", _Class = 10, Section = "A" };
            Student s2 = new Student() { Name = "Ramesh", _Class = 11, Section = "B" };
            Student s3 = new Student() { Name = "Haresh", _Class = 10, Section = "C" };
            Student s4 = new Student() { Name = "Jagdish", _Class = 11, Section = "D" };
            Student s5 = new Student() { Name = "Prakash", _Class = 12, Section = "F" };
            dc.students.Add(s1);
            dc.students.Add(s2);
            dc.students.Add(s3);
            dc.students.Add(s4);
            dc.students.Add(s5);
            dc.SaveChanges();
            return View();
        }
    }
}
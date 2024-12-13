using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using MVCWithEFCF3.Models;

namespace MVCWithEFCF3.Controllers
{
    public class StudentController : Controller
    {
        SchoolDBContext dc = new SchoolDBContext();
        // GET: Student
        public ActionResult Index()
        {
            Student student = new Student() { Name = "Mahesh" };
            dc.Students.Add(student);
            dc.SaveChanges();
            return View();
        }
    }
}
using MVCUIDesigning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUIDesigning.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddStudent(Student student)
        {
            return View("DisplayStudent", student);
        }

        public ViewResult AddStudentST()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddStudentST(Student student)
        {
            return View("DisplayStudentST", student);
        }
        ////also possible to reun by using http://localhost:50164/Student/Header
        public PartialViewResult Header()
        {            
            return PartialView("_Header");
        }
    }
}
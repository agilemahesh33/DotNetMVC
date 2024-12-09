using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithEFDBF3.Models;

namespace MVCWithEFDBF3.Controllers
{
    public class StudentController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        public ViewResult DisplayStudents()
        {
            var students = dc.Student_Select(null, true);
            return View(students);
        }
    }
}
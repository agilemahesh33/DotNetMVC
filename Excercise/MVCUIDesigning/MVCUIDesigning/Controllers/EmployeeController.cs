using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUIDesigning.Models;

namespace MVCUIDesigning.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ViewResult AddEmployee()
        {
            return View();
        }

        //Way 1
        //[HttpPost]
        //public ViewResult AddEmployee(int? Id, string Name, string Job, double? Salary)
        //{
        //    ViewData["Id"]=Id;
        //    ViewData["Name"]=Name;
        //    ViewData["Job"] = Job;
        //    ViewData["Salary"] = Salary;
        //    return View("DisplayEmp1");
        //}

        //Way 2
        //[HttpPost]
        //public ViewResult AddEmployee (FormCollection formCollection)
        //{
        //    ViewData["Id"] = formCollection["Id"];
        //    ViewData["Name"] = formCollection["Name"];
        //    ViewData["Job"] = formCollection["Job"];
        //    ViewData["Salary"] = formCollection["Salary"];
        //    return View("DisplayEmp1");
        //}

        //Way 3 :Model Binding, Include namespace controller and in view as well.
        [HttpPost]
        public ViewResult AddEmployee(Employee employee)
        {            
            return View("DisplayEmp2",employee);
        }

    }
}
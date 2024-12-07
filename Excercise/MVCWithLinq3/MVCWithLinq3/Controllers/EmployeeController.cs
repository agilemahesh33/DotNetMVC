using MVCWithLinq3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq3.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL dal = new EmployeeDAL();
        public ViewResult DisplayEmployees()
        {
            var Emps = dal.GetEmployees(null);
            return View(Emps);
        }
        public ViewResult DisplayEmployee(int Eid)
        {
            var Emps = dal.GetEmployee(Eid,true);
            return View(Emps);
        }
        public ViewResult AddEmployee()
        {
            //To Load Department List with Did
            EmpDept dept = new EmpDept();
            dept.Departments = dal.GetDepartments();
            return View(dept);
        }
        [HttpGet]
        public RedirectToRouteResult EditEmployee (int Eid)
        {
            return RedirectToAction("");
        }
    }
}
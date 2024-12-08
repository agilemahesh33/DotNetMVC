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
            var Emps = dal.GetEmployees(true);
            return View(Emps);
        }
        public ViewResult DisplayEmployee(int Eid)
        {
            var Emps = dal.GetEmployee(Eid, true);
            return View(Emps);
        }
        [HttpGet]
        public ViewResult AddEmployee()
        {
            //To Load Department List with Did
            EmpDept dept = new EmpDept();
            dept.Departments = dal.GetDepartments();
            return View(dept);
        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept emp)
        {
            dal.InsertEmployee(emp);
            return RedirectToAction("DisplayEmployees");
        }
        [HttpGet]
        public ViewResult EditEmployee(int Eid)
        {
            EmpDept Emp = dal.GetEmployee(Eid, true);
            Emp.Departments = dal.GetDepartments();
            return View(Emp);
        }
        [HttpPost]
        public RedirectToRouteResult EditEmployee(EmpDept emp)
        {
            dal.UpdateEmployee(emp);
            return RedirectToAction("DisplayEmployees");
        }
        public RedirectToRouteResult DeleteEmployee(int Eid)
        {
            dal.DeleteEmployee(Eid);
            return RedirectToAction("DisplayEmployees");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithEFDBF2.Models;


namespace MVCWithEFDBF2.Controllers
{
    public class EmployeeController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        public ViewResult DisplayEmployees()
        {
            var emps = dc.Employees.Where(E => E.Status == true);
            return View(emps);
        }
        public ViewResult DisplayEmployee(int empid)
        {
            var emp = dc.Employees.Find(empid);
            return View(emp);
        }
        [HttpGet]
        public ViewResult AddNewEmployee()
        {
            ViewBag.Did = new SelectList(dc.Departments, "Did", "DName");
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddNewEmployee(Employee emp)
        {
            emp.Status = true;
            dc.Employees.Add(emp);
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }
        [HttpGet]
        public ViewResult EditEmployee(int empid)
        {
            var emps = dc.Employees.Find(empid);
            ViewBag.Did = new SelectList(dc.Departments, "Did", "DName", emps.Did);
            return View(emps);
        }
        [HttpPost]
        public RedirectToRouteResult EditEmployee(Employee Emp)
        {
            Emp.Status = true;
            dc.Entry(Emp).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }
        [HttpGet]
        public ViewResult DeleteEmployee(int empid)
        {
            var emp = dc.Employees.Find(empid);
            return View(emp);
        }
        [HttpPost]
        public RedirectToRouteResult DeleteEmployee(Employee Emp)
        {
            //Delete Permenently 
            //dc.Employees.Remove(Emp);
            //Update Status only            
            dc.Entry(Emp).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }
        //[HttpPost]
        //public RedirectToRouteResult DeleteEmployee(Employee Emp)
        //{            
        //    dc.Entry(Emp).State = System.Data.Entity.EntityState.Modified;
        //    dc.SaveChanges();
        //    return RedirectToAction("DisplayEmployees");
        //}
    }
}
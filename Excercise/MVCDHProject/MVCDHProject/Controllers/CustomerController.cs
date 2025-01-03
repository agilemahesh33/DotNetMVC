﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCDHProject.Models;

namespace MVCDHProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerDAL dal;

        public CustomerController(ICustomerDAL dal)
        {
            this.dal = dal;
        }
        [AllowAnonymous]
        public IActionResult DisplayCustomers()
        {
            var customer = dal.Select_Customers();
            return View(customer);
        }
        [AllowAnonymous]
        public IActionResult DisplayCustomer(int CustId)
        {
            var customer = dal.Select_Customer(CustId);
            if (customer == null)
            {
                throw new Exception("No Customer Exists with Given Customer ID");
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            dal.Customer_Insert(customer);
            return RedirectToAction("DisplayCustomers");
        }
        public IActionResult EditCustomer(int Custid)
        {
            return View(dal.Select_Customer(Custid));
        }
        public IActionResult UpdateCustomer(Customer customer)
        {
            dal.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }
        public IActionResult DeleteCustomer(int Custid)
        {
            dal.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }
    }
}

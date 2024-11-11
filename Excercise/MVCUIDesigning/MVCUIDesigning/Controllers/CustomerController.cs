using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using MVCUIDesigning.Models;

namespace MVCUIDesigning.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult DisplayCustomers()
        {
            Customer c1 = new Customer()
            {
                CustId = 1001,
                Name = "RAM",
                Account = "Savings",
                Balance = 50000,
                City = "Pune",
                Status = true,
                Photo = "~/Images/Image1.jpg"
            };
            Customer c2 = new Customer()
            {
                CustId = 1002,
                Name = "SHAM",
                Account = "Current",
                Balance = 50000,
                City = "Mumbai",
                Status = true,
                Photo = "~/Images/Image2.jpg"
            };
            Customer c3 = new Customer()
            {
                CustId = 1003,
                Name = "GANESH",
                Account = "Demat",
                Balance = 50000,
                City = "Solapur",
                Status = true,
                Photo = "~/Images/Image3.jpg"
            };
            Customer c4 = new Customer()
            {
                CustId = 1004,
                Name = "RAMESH",
                Account = "Demat",
                Balance = 50000,
                City = "Pune",
                Status = true,
                Photo = "~/Images/Image4.jpg"
            };
            Customer c5 = new Customer()
            {
                CustId = 1005,
                Name = "MAHESH",
                Account = "Savings",
                Balance = 50000,
                City = "Pune",
                Status = true,
                Photo = "~/Images/Image5.jpg"
            };
            Customer c6 = new Customer()
            {
                CustId = 1006,
                Name = "PRATIK",
                Account = "Current",
                Balance = 33000,
                City = "Nashik",
                Status = true,
                Photo = "~/Images/Image6.jpg"
            };
            List<Customer> cust = new List<Customer>() { c1, c2, c3, c4, c5, c6 };
            return View(cust);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithEFCF2.Models;

namespace MVCWithEFCF2.Controllers
{
    public class SupplierController : Controller
    {
        CompanyDBContext dc = new CompanyDBContext();
        public ActionResult Index()
        {
            Supplier s1 = new Supplier { Sid = 131, SupplierName = "Ashok Distributor" };
            Supplier s2 = new Supplier { Sid = 132, SupplierName = "Meghna Distributor" };
            Supplier s3 = new Supplier { Sid = 133, SupplierName = "Diamond Distributor" };
            Supplier s4 = new Supplier { Sid = 134, SupplierName = "Prathmesh Distributor" };
            Supplier s5 = new Supplier { Sid = 135, SupplierName = "Arihant Distributor" };
            Supplier s6 = new Supplier { Sid = 136, SupplierName = "Prasad Distributor" };
            dc.Suppliers.Add(s1);
            dc.Suppliers.Add(s2);
            dc.Suppliers.Add(s3);
            dc.Suppliers.Add(s4);
            dc.Suppliers.Add(s5);
            dc.Suppliers.Add(s6);
            dc.SaveChanges();
            return View(dc.Suppliers);
        }
    }
}
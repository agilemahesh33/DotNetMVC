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
            return View(dc.Suppliers);
        }
    }
}
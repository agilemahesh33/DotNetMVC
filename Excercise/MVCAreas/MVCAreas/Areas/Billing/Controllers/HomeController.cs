using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAreas.Areas.Billing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Billing/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
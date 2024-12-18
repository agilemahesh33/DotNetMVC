using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithFormsAuth.Filters;

namespace MVCAppWithFormsAuth.Controllers
{
    [AuthenticateFilter] // Controller Level filter to aply it to all methods in same controller
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
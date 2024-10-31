using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCActionResults.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Register()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }
    }
}
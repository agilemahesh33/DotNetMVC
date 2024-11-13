using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAreas.Areas.Labs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Labs/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
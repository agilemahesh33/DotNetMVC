using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAreas.Areas.Marketing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Marketing/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
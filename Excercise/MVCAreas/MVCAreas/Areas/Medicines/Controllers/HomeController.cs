using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAreas.Areas.Medicines.Controllers
{
    public class HomeController : Controller
    {
        // GET: Medicines/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
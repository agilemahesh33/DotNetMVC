using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestEmptyProject3.Controllers
{
    public class DemoController : Controller
    {
        public string Index()
        {
            return "Hellow from Demo Controller : Index Action";
        }
        public string Show()
        {
            return "Hello From Demo Controller : Show Action";
        }
        //// GET: Demo
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}
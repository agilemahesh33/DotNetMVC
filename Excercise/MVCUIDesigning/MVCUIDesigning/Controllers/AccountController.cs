using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUIDesigning.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Validate()
        {
            string uname = Request["txtName"];
            string password = Request["txtPwd"];
            if (uname == "Mahesh" && password == "3303")
            {
                Session["username"] = uname;
                return View("Success");
            }
            else
            {
                ViewData["username"] = uname;
                return View("Failure");
            }
        }        
    }
}
using MVCDataAnnotations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataAnnotations.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ViewResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                return View("DisplayUser", user);
            }
            else
            {
                return View("Index", user);
            }
        }
    }
}
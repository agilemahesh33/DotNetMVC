﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilters.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult BadRequest()
        {
            return View();
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
        public ActionResult PaymentRequired()
        {
            return View();
        }
        public ActionResult Forbidden()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
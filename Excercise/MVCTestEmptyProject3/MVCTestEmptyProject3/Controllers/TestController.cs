using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestEmptyProject3.Controllers
{
    public class TestController : Controller
    {
        public string Index()
        {
            return "Hellow from TestController : Index Action";
        }
        public string Show()
        {
            return "Hello From TestController : Show Action";
        }
    }
}
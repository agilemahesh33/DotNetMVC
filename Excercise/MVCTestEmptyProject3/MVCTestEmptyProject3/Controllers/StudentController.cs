using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestEmptyProject3.Controllers
{
    public class StudentController : Controller
    {
        public string Index()
        {
            return "Hellow from Student Controller : Index Action";
        }
    }
}
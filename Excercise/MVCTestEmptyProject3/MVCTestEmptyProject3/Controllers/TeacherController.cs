using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestEmptyProject3.Controllers
{
    public class TeacherController : Controller
    {
        public string Show()
        {
            return "Hello From <strong>Teacher</strong> Controller : Show Action";
        }
    }
}
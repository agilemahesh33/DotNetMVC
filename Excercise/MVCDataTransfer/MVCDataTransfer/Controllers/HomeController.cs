using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataTransfer.Controllers
{
    public class HomeController : Controller
    {
    /*
    Drawbacks of ViewData:
1.	ViewData can transfer data from a Controllers - Action method to its corresponding View only.
2.	ViewData life lasts only during the current HTTP request i.e., ViewData values will be cleared if redirection occurs.
3.	ViewData is resolved dynamically at runtime, as a result, it doesn’t provide any compile-time error checking as well as we do not get support of Intellisense. For example, if we miss-spell the “Key Names” then we will not get any compile-time or runtime error also, whereas we come to know about the problem at the runtime because the value is not displayed.
4.	ViewData values must be converted into an appropriate type (un-boxing) before using them because they are present in object format, as we have performed in-case of Price value to calculate 10% Tax.
Note: we can store scalar as well as complex types also in ViewData but while accessing them we need to explicitly convert them into its original type again. To test this, add a new Action method in “HomeController” class as below:

    */
        public ViewResult Index1(int? id, string name, double? price)
        {
            ViewData["Id"] = id;
            ViewData["Name"] = name;
            ViewData["Price"] = price;
            return View();
        }
        public ViewResult Dispay1()
        {
            List<string> Colors = new List<string>() { "Red", "Blue", "Pink", "Black", "White", "Green", "Brown", "Purple" };
            ViewData["colors"] = Colors;
            return View();
        }
    }
}

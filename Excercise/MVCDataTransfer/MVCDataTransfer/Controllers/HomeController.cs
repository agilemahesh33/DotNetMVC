using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDataTransfer.Models;

namespace MVCDataTransfer.Controllers
{
    public class HomeController : Controller
    {
        #region ViewData
        /*
        Drawbacks of ViewData:
    1.	ViewData can transfer data from a Controllers - Action method to its corresponding View only.
    2.	ViewData life lasts only during the current HTTP request 
        i.e., ViewData values will be cleared if redirection occurs.
    3.	ViewData is resolved dynamically at runtime, as a result, 
        it doesn’t provide any compile-time error checking as well as 
        we do not get support of Intellisense. For example, if we miss-spell the “Key Names” 
        then we will not get any compile-time or runtime error also, 
        whereas we come to know about the problem at the runtime because the value is not displayed.
    4.	ViewData values must be converted into an appropriate type (un-boxing) before using them 
        because they are present in object format, as we have performed 
        in-case of Price value to calculate 10% Tax.
    Note: we can store scalar as well as complex types also in ViewData 
        but while accessing them we need to explicitly convert them into its original type again. 
        To test this, add a new Action method in “HomeController” class as below:

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
        #endregion ViewData

        #region ViewBag

        /*
        “ViewBag” is a wrapper around “ViewData” i.e., data that is stored in the “ViewBag” will be 
        internally stored in “ViewDataDictionary” only, so values that are stored in a “ViewBag” can
        also be accessed thru “ViewData” and vice-versa. To test this, go to “Index2.cshtml” and 
        change the statement @ViewBag.Id to @ViewData["Id"] and execute Index2 action method and 
        still we get the same output as before.

        Note: ViewBag is “Type Safe”, i.e., it doesn't require any type conversions while accessing 
        data because we get the values back in their original types only, whereas ViewData requires 
        type conversion because values are stored as object. ViewData and ViewBag are accessible 
        only within the request i.e., with-in the corresponding View associated with Action Methods. 
        In case of both if “Key Names” are misspelled then we don’t get compile-time or runtime error.
         */
        public ViewResult Index2(int? id, string name, double? price)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Price = price;
            return View();
        }
        public ViewResult Dispay2()
        {
            List<string> Colors = new List<string>() { "Red", "Blue", "Pink", "Black", "White", "Green", "Brown", "Purple" };
            ViewBag.colors = Colors;
            return View();
        }
        #endregion ViewBag


        #region Model Object
        public ViewResult Index15(int? id, string name, double? price)
        {
            Products prod = new Products {  Id = id, Name = name, Price = price };
            return View(prod);
           
        }
        public RedirectToRouteResult Index16(Products prod)
        {
            return RedirectToAction("Index6", "Test", prod);
        }
        public ViewResult Index6(Products prod)
        {
            return View(prod);
        }
        #endregion Model Object
    }
}

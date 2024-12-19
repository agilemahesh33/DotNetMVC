using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppUsingAjax.Models;

namespace MVCAppUsingAjax.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities dc = new NorthwindEntities();
        // GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult DisplayProducts()
        {
            return View(dc.Products);
        }
        public ViewResult SearchProduct(string SearchTerm)
        {
            List<Product> products = new List<Product>();
            if (string.IsNullOrEmpty(SearchTerm))
            {
                products = dc.Products.ToList();
            }
            else
            {
                //products = (from P in dc.Products where P.ProductName.Contains(SearchTerm) select P).ToList();
                products = dc.Products.Where(P => P.ProductName.Contains(SearchTerm)).ToList();
            }
            return View("DisplayProducts", products);
        }
        public JsonResult GetProductsName(string term)
        {
            //var ProductNameList = (from P in dc.Products where P.ProductName.StartsWith(term) select new { P.ProductName }).ToList();
            var ProductNameList = dc.Products.Where(P => P.ProductName.StartsWith(term)).Select(P => P.ProductName).ToList();
            return Json(ProductNameList, JsonRequestBehavior.AllowGet);
        }
    }
}
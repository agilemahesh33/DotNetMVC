using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithEFCF1.Models;

namespace MVCWithEFCF1.Controllers
{
    public class CategoryController : Controller
    {
        StoreDBContext dc = new StoreDBContext();
        public ViewResult DisplayCategories()
        {
            var categories = dc.Categories;
            return View(categories);
        }
        public ViewResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddCategory(Category category)
        {
            dc.Categories.Add(category);
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
        public ViewResult EditCategory(int CategoryId)
        {
            Category category = dc.Categories.Find(CategoryId);
            return View(category);
        }
        public RedirectToRouteResult UpdateCategory(Category category)
        {
            dc.Entry(category).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
        public RedirectToRouteResult DeleteCategory(int CategoryId)
        {
            Category category = dc.Categories.Find(CategoryId);
            dc.Categories.Remove(category);
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
    }
}
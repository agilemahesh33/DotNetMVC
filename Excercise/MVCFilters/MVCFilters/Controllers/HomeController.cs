using System.Web.Mvc;
using MVCFilters.Models;
using System.Linq;
using System.Web.Caching;

namespace MVCFilters.Controllers
{
    public class HomeController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        #region ChildActionOnly Filter
        public ViewResult DisplayDepts()
        {
            return View(dc.Departments);
        }
        [ChildActionOnly]
        public ViewResult DisplayEmpByDID(int DID)
        {
            var EmpdeptID = from E in dc.Employees where E.Did == DID select E;
            return View(EmpdeptID);
        }
        #endregion ChildActionOnly Filter

        #region OutputCache Filter
        public ViewResult DisplayCustomers1()
        {
            return View(dc.Customers);
        }
        [OutputCache(Duration =60)]
        public ViewResult DisplayCustomers2()
        {
            return View(dc.Customers);
        }
        [OutputCache(Duration =60, VaryByParam ="City")] //VaryByParam is optional 
        public ViewResult DisplayCustomers3(string City)
        {
            return View(dc.Customers.Where(C => C.City == City));
        }
        [OutputCache(Duration = 60, VaryByCustom ="browser")] //VaryByParam is optional 
        public ViewResult DisplayCustomers4(string City)
        {
            return View(dc.Customers.Where(C => C.City == City));
        }

        [OutputCache(CacheProfile = "MyCacheProfile")]
        public ViewResult DisplayCustomers5(string City)
        {
            return View(dc.Customers.Where(C => C.City == City));
        }

        #endregion OutputCache Filter

        #region ValidateInput Filter
        //ValidateInput By Default true to make it false use it wisely
        [HttpGet, ValidateInput(false)]
        public ViewResult GetComments()
        {
            return View();
        }
        [HttpPost]
        public string GetComments(string txtComment)
        {
            return txtComment;
        }
        #endregion ValidateInput Filter
    }
}
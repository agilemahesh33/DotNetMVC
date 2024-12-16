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
        #endregion OutputCache Filter
    }
}
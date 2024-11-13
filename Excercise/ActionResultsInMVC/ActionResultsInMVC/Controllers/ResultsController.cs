using ActionResultsInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ActionResultsInMVC.Controllers
{
    public class ResultsController : Controller
    {
        public ActionResult Index()
            { return View(); }
        public JsonResult getEmployees()
        {
            Employee e1 = new Employee { Id = 11, Name = "MAAHESH", Job = "ANALYST", Salary = 15000, Status = true };
            Employee e2 = new Employee { Id = 22, Name = "RAMESH", Job = "MANAGER", Salary = 17999, Status = true };
            Employee e3 = new Employee { Id = 33, Name = "DURGA", Job = "MANAGER", Salary = 173084, Status = true };
            Employee e4 = new Employee { Id = 44, Name = "PRATIK", Job = "CLERK", Salary = 23433, Status = true };
            Employee e5 = new Employee { Id = 55, Name = "ANKUR", Job = "ACCOUNTANT", Salary = 23445, Status = true };
            Employee e6 = new Employee { Id = 66, Name = "MANOJ", Job = "ANALYST", Salary = 53234, Status = true };
            List<Employee> emps = new List<Employee>() { e1, e2, e3, e4, e5, e6 };
            return Json(emps, JsonRequestBehavior.AllowGet);
        }
        public FileResult DownloadPDF()
        {
            //MIME type for pdf is "application/pdf"
            return File("~/Downloads/Baradkar Mahesh Manikrao.pdf", "application/pdf");
        }
        public FileResult DownloadWord()
        {
            //MIME type for word (doc)file is "application/msword"
            return File("~/Download/Baradkar Mahesh Manikrao.docs", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }
        public RedirectResult OpenGmail()
        {
            return Redirect("https://accounts.google.com/");
        }
        public RedirectResult OpenTwitter()
        {
            return Redirect("https://x.com/");
        }
        public ContentResult SayHello()
        {

            return Content("Current Date is : " + System.DateTime.Now.ToString());
        }
        public ContentResult SayHello1()
        {
            return Content("नमस्ते ! आप कैसे हो ।");
        }
        public ContentResult SayHello2()
        {
            return Content("नमस्ते ! आप कैसे हो ।", "text/plain", Encoding.Unicode);
        }
    }
}
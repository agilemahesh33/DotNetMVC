using Microsoft.AspNetCore.Mvc;

namespace CoreTestProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiConsumer1.Controllers
{
    public class TestApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

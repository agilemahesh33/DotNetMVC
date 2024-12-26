using Microsoft.AspNetCore.Mvc;

namespace MVCCoreTagHelpers.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}

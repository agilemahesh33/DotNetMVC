using Microsoft.AspNetCore.Mvc;

namespace CoreTestProject.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Disp1/{id?}")]
        public string Display1(int id)
        {
            return "Value of id is " + id;
        }
        [Route("Disp2/{id:int}")]
        public string Display2(int id)
        {
            return "Value of id is " + id;
        }
        [Route("Display3/{id:double?}")]
        public string Display3(double id)
        {
            return "Value of id is: " + id;
        }
        [Route("Display4/{id:min(50)}")]
        public string Display4(int id)
        {
            return "Value of id is: " + id;
        }
        [Route("Display5/{id:max(100)}")]
        public string Display5(int id)
        {
            return "Value of id is: " + id;
        }
        [Route("Display6/{id:range(51, 100)}")]
        public string Display6(int id)
        {
            return "Value of id is: " + id;
        }
        [Route("Display7/{name:length(5)}")]
        public string Display7(string name)
        {
            return "Name of the user is: " + name;
        }
        [Route("Display8/{name:length(3, 10)}")]
        public string Display8(string name)
        {
            return "Name of the user is: " + name;
        }
        [Route("Display9/{name:minlength(3)}")]
        public string Display9(string name)
        {
            return "Name of the user is: " + name;
        }
        [Route("Display10/{name:maxlength(10)}")]
        public string Display10(string name)
        {
            return "Name of the user is: " + name;
        }
        [Route("Display11/{name:alpha}")]
        public string Display11(string name)
        {
            return "Name of the user is: " + name;
        }
        [Route("Display12/{flag:bool}")]
        public string Display12(bool flag)
        {
            if (flag)
                return "Hello India!";
            else
                return "Hello World!";
        }
        [Route("Display13/{aadhar:regex(^\\d{{4}}-\\d{{4}}-\\d{{4}}$)}")]
        public string Display13(string aadhar)
        {
            return "Aadhar Id of the user is: " + aadhar;
        }
        [Route("Display14/{id}/{name}")]
        public string Display14(int id, string name)
        {
            return "Id of the user is: " + id + " and name of the user is: " + name;
        }
    }
}

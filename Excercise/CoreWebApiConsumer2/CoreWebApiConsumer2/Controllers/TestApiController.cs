using CoreWebApiConsumer2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWebApiConsumer2.Controllers
{
    public class TestApiController : Controller
    {
        HttpClient client = new HttpClient();
        string serviceUri = "http://localhost/CoreWebApiService/";
        public async Task<IActionResult> DisplayCustomers()
        {
            List<Customer> customers = new List<Customer>();
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage responseMessage = await client.GetAsync("Customer");
            if (responseMessage.IsSuccessStatusCode)
            {
                string result = responseMessage.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(result);
            }
            return View(customers);
        }
        public async Task<IActionResult> DisplayCustomer(int Custid)
        {
            Customer customer = new Customer();
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.GetAsync("Customer/" + Custid);
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }
            return View(customer);
        }
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.PostAsJsonAsync("Customer", customer);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("DisplayCustomers");
            else
                return View();
        }

        public async Task<IActionResult> EditCustomer(int Custid)
        {
            Customer customer = new Customer();
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.GetAsync("Customer/" + Custid);
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }
            return View(customer);
        }

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.PutAsJsonAsync("Customer", customer);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("DisplayCustomers");
            else
                return View("EditCustomer");
        }

        public async Task<IActionResult> DeleteCustomer(int Custid)
        {
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.DeleteAsync("Customer/" + Custid);
            if (!response.IsSuccessStatusCode)
                ModelState.AddModelError("", "Delete action resulted in an error");
            return RedirectToAction("DisplayCustomers");
        }
    }
}

using CoreWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreWebApiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDAL dal;

        public CustomerController(ICustomerDAL dal)
        {
            this.dal = dal;
        }
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return dal.Customers_Select();
        }
        [HttpGet("{Custid}")]
        public Customer GetCustomer(int Custid)
        {
            return dal.Customer_Select(Custid);
        }
        [HttpPost]
        public HttpResponseMessage Post(Customer c)
        {
            dal.Customer_Insert(c);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpPut]
        public HttpResponseMessage Put(Customer c)
        {
            Customer customer = dal.Customer_Select(c.Custid);
            if (customer != null)
            {
                dal.Customer_Update(c);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
        [HttpDelete("{Custid}")]
        public HttpResponseMessage Delete(int Custid)
        {
            Customer customer = dal.Customer_Select(Custid);
            if (customer != null)
            {
                dal.Customer_Delete(Custid);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}

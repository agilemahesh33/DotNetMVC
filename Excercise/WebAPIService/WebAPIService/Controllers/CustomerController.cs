using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class CustomerController : ApiController
    {
        MVCDBEntities dc = new MVCDBEntities();
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    //no need of conversion because of IEnumerable
        //    var customer = dc.Customers;//.Where(P => P.Status == true); Handled at front end during API Call
        //    return customer;
        //}
        //http://localhost:58069/api/Customer/
        public List<Customer> GetCustomers()
        {
            //no need of conversion because of IEnumerable
            var customer = dc.Customers;//.Where(P => P.Status == true); Handled at front end during API Call
            return customer.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return (dc.Customers.Find(id));
        }
        public HttpResponseMessage Post(Customer cust)
        {
            try
            {
                cust.Status = true;
                dc.Customers.Add(cust);
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage Put(Customer cust)
        {
            try
            {
                Customer customer = dc.Customers.Find(cust.CustId);
                if (customer == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                customer.Name = cust.Name;
                customer.Balance = cust.Balance;
                customer.City = cust.City;
                dc.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Customer customer = dc.Customers.Find(id);
                if (customer == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                customer.Status = false;
                dc.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
              throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
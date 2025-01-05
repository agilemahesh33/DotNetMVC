using CoreRazorPagesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPagesDemo.Pages
{
    public class AddCustomerModel : PageModel
    {
        private readonly MvcdbContext context;
        public Customer Customer { get; set; }
        public AddCustomerModel(MvcdbContext context)
        {
            this.context = context;
        }
        //public void OnGet()
        //{
        //    Customer = new Customer();
        //}
        public ActionResult OnPost(Customer customer)
        {
            context.Add(customer);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}

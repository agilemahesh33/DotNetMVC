using CoreRazorPagesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace CoreRazorPagesDemo.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        public Customer Customer { get; set; }
        private readonly MvcdbContext context;
        public DeleteCustomerModel(MvcdbContext context)
        {
            this.context = context;
        }

        public void OnGet(int CustId)
        {
            Customer = context.Customers.Find(CustId);
        }
        public RedirectResult OnPost(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}

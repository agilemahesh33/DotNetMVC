using CoreRazorPagesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPagesDemo.Pages
{
    public class EditCustomerModel : PageModel
    {
        public Customer Customer { get; set; }
        private readonly MvcdbContext context;

        public EditCustomerModel(MvcdbContext context)
        {
            this.context = context;
        }
        public void OnGet(int CustId)
        {
            Customer = context.Customers.Find(CustId);

        }
        public ActionResult OnPost(Customer customer)
        {
            context.Update(customer);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}

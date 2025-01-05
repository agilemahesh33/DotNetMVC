using CoreRazorPagesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPagesDemo.Pages
{
    public class DisplayCustomerModel : PageModel
    {
        public Customer Customer { get; set; }
        private readonly MvcdbContext context;

        public DisplayCustomerModel(MvcdbContext context)
        {
            this.context = context;
        }
        public void OnGet(int CustId)
        {
            Customer = context.Customers.Find(CustId);
        }
    }
}

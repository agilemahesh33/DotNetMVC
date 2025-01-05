using CoreRazorPagesDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreRazorPagesDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MvcdbContext context;
        public List<Customer> Customers { get; set; }
        public IndexModel (MvcdbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Customers = context.Customers.Where(C => C.Status == true).ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace MVCDHProject.Models
{
    public class MVCCoreDbContext : DbContext
    {
        public MVCCoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}

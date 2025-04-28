using Microsoft.EntityFrameworkCore;
using WebAPIGenericRepoDP.Entity;

namespace WebAPIGenericRepoDP.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; } 
        public DbSet<Customers> Customers { get; set; }
        public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }
        //https://learn.microsoft.com/en-us/ef/core/modeling/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Products)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProdId);                
        }
    }
}

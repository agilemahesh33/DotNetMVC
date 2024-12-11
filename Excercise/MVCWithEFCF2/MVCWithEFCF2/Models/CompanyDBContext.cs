using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCWithEFCF2.Models
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() : base("ConStr")
        {
            Database.SetInitializer(new CompanyDBInitializer());
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCWithEFCF2.Models
{
    public class CompanyDBInitializer : DropCreateDatabaseAlways<CompanyDBContext>
    {
        protected override void Seed(CompanyDBContext context)
        {
            Supplier s1 = new Supplier { Sid = 131, SupplierName = "Ashok Distributor" };
            Supplier s2 = new Supplier { Sid = 132, SupplierName = "Meghna Distributor" };
            Supplier s3 = new Supplier { Sid = 133, SupplierName = "Diamond Distributor" };
            Supplier s4 = new Supplier { Sid = 134, SupplierName = "Prathmesh Distributor" };
            Supplier s5 = new Supplier { Sid = 135, SupplierName = "Arihant Distributor" };
            Supplier s6 = new Supplier { Sid = 136, SupplierName = "Prasad Distributor" };
            context.Suppliers.Add(s1);
            context.Suppliers.Add(s2);
            context.Suppliers.Add(s3);
            context.Suppliers.Add(s4);
            context.Suppliers.Add(s5);
            context.Suppliers.Add(s6);
            context.SaveChanges();
        }
    }
}
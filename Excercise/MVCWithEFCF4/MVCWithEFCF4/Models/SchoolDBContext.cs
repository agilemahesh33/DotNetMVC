using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCWithEFCF4.Migrations;
using System.Configuration;


namespace MVCWithEFCF4.Models
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("ConStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion(SchoolDBContext, Configuration));
        }
        public DbSet<Student> students { get; set; }
    }
}
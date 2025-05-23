﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace MVCWithEFCF3.Models
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("ConStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDBContext,MVCWithEFCF3.Migrations.Configuration>());
        }
        public DbSet<Student> Students { get; set; }
    }
}
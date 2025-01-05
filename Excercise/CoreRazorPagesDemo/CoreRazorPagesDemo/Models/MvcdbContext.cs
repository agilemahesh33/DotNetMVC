using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreRazorPagesDemo.Models;

public partial class MvcdbContext : DbContext
{
    public MvcdbContext()
    {
    }

    public MvcdbContext(DbContextOptions<MvcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-N9LCSVV9;User Id=Sa;Password=MSSQL@123;Database=MVCDB;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__049E3AA9EF59628E");

            entity.ToTable("Customer");

            entity.Property(e => e.CustId).ValueGeneratedNever();
            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

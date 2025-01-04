using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCoreDBF.Models;

public partial class MvcdbContext : DbContext
{
    public MvcdbContext()
    {
    }

    public MvcdbContext(DbContextOptions<MvcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-N9LCSVV9;User Id=Sa;Password=MSSQL@123;Database=MVCDB;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Student__CA1E5D787B912C71");

            entity.ToTable("student");

            entity.Property(e => e.Sid).ValueGeneratedNever();
            entity.Property(e => e.Fees).HasColumnType("money");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

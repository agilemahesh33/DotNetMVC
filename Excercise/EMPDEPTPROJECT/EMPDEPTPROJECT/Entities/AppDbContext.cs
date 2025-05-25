using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMPDEPTPROJECT.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MAHESH;Database=CoreCFGenDP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__Departme__0148CAAE027331F4");

            entity.HasOne(d => d.HodEmpNoNavigation).WithMany(p => p.Departments).HasConstraintName("FK__Departmen__HOD_E__6B24EA82");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__AF2D66D38C966520");

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__DeptN__6C190EBB");

            entity.HasOne(d => d.MgrNavigation).WithMany(p => p.InverseMgrNavigation).HasConstraintName("FK__Employees__Mgr__6754599E");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => new { e.EmpNo, e.ProjectId, e.AssignedFrom }).HasName("PK__Employee__A96479FA54967C26");

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.EmployeeProjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeP__EmpNo__6FE99F9F");

            entity.HasOne(d => d.Project).WithMany(p => p.EmployeeProjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeP__Proje__70DDC3D8");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF0035C618C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

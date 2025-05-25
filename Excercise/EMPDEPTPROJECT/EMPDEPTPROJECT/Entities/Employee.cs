using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMPDEPTPROJECT.Entities;

public partial class Employee
{
    [Key]
    public int EmpNo { get; set; }

    [Column("EName")]
    [StringLength(50)]
    [Unicode(false)]
    public string Ename { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Job { get; set; }

    public int? Mgr { get; set; }

    public DateOnly? HireDate { get; set; }

    [Column(TypeName = "money")]
    public decimal? Sal { get; set; }

    [Column(TypeName = "money")]
    public decimal? Comm { get; set; }

    public int DeptNo { get; set; }

    [InverseProperty("HodEmpNoNavigation")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [ForeignKey("DeptNo")]
    [InverseProperty("Employees")]
    public virtual Department DeptNoNavigation { get; set; } = null!;

    [InverseProperty("EmpNoNavigation")]
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    [InverseProperty("MgrNavigation")]
    public virtual ICollection<Employee> InverseMgrNavigation { get; set; } = new List<Employee>();

    [ForeignKey("Mgr")]
    [InverseProperty("InverseMgrNavigation")]
    public virtual Employee? MgrNavigation { get; set; }
}

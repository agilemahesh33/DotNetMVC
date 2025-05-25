using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMPDEPTPROJECT.Entities;

public partial class Department
{
    [Key]
    public int DeptNo { get; set; }

    [Column("DName")]
    [StringLength(100)]
    [Unicode(false)]
    public string Dname { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column("HOD_EmpNo")]
    public int? HodEmpNo { get; set; }

    [InverseProperty("DeptNoNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("HodEmpNo")]
    [InverseProperty("Departments")]
    public virtual Employee? HodEmpNoNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMPDEPTPROJECT.Entities;

[PrimaryKey("EmpNo", "ProjectId", "AssignedFrom")]
public partial class EmployeeProject
{
    [Key]
    public int EmpNo { get; set; }

    [Key]
    public int ProjectId { get; set; }

    [Key]
    public DateOnly AssignedFrom { get; set; }

    public DateOnly? AssignedTo { get; set; }

    [ForeignKey("EmpNo")]
    [InverseProperty("EmployeeProjects")]
    public virtual Employee EmpNoNavigation { get; set; } = null!;

    [ForeignKey("ProjectId")]
    [InverseProperty("EmployeeProjects")]
    public virtual Project Project { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EMPDEPTPROJECT.Entities;

public partial class Project
{
    [Key]
    public int ProjectId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ProjectName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? ClientName { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}

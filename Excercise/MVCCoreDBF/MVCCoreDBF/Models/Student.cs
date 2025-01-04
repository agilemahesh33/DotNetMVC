using System;
using System.Collections.Generic;

namespace MVCCoreDBF.Models;

public partial class Student
{
    public int Sid { get; set; }

    public string? Name { get; set; }

    public int? Class { get; set; }

    public decimal? Fees { get; set; }

    public string? Photo { get; set; }

    public bool Status { get; set; }
}

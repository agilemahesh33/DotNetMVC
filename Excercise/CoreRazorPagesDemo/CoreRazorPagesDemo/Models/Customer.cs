using System;
using System.Collections.Generic;

namespace CoreRazorPagesDemo.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string? Name { get; set; }

    public decimal? Balance { get; set; }

    public string? City { get; set; }

    public bool Status { get; set; }
}

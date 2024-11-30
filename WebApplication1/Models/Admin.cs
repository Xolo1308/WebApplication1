using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

    
public partial class Admin
{
    public int UserId { get; set; }
    public string? UserName  { get; set; }
    public string? UserEmail { get; set; }
    public string? Password { get; set; }
    public bool? IsActive { get; set; }
}

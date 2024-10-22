using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TbRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TblAccountld> TblAccountlds { get; set; } = new List<TblAccountld>();
}

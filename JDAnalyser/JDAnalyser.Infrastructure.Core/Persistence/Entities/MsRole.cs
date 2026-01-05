using System;
using System.Collections.Generic;

namespace JDAnalyser.Infrastructure.Persistence.Persistence.Entities;

public partial class MsRole
{
    public int MsRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<MsUser> MsUsers { get; set; } = new List<MsUser>();
}

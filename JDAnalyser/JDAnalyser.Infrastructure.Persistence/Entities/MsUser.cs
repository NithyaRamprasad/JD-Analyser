using System;
using System.Collections.Generic;

namespace JDAnalyser.Infrastructure.Persistence.Entities;

public partial class MsUser
{
    public int MsUserId { get; set; }

    public string EmailId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime LastAccessed { get; set; }

    public int Role { get; set; }

    public virtual ICollection<JobDescription> JobDescriptionCreatedByNavigations { get; set; } = new List<JobDescription>();

    public virtual ICollection<JobDescription> JobDescriptionModifiedByNavigations { get; set; } = new List<JobDescription>();

    public virtual ICollection<JobSummary> JobSummaryCreatedByNavigations { get; set; } = new List<JobSummary>();

    public virtual ICollection<JobSummary> JobSummaryModifiedByNavigations { get; set; } = new List<JobSummary>();

    public virtual MsRole RoleNavigation { get; set; } = null!;
}

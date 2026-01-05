using System;
using System.Collections.Generic;

namespace JDAnalyser.Infrastructure.Persistence.Entities;

public partial class JobDescription
{
    public int JobDescriptionId { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MsUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<JobSummary> JobSummaries { get; set; } = new List<JobSummary>();

    public virtual MsUser? ModifiedByNavigation { get; set; }
}

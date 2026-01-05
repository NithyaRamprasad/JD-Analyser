using System;
using System.Collections.Generic;

namespace JDAnalyser.Infrastructure.Persistence.Entities;

public partial class JobSummary
{
    public int JobSummaryId { get; set; }

    public string? Summary { get; set; }

    public int JobDescriptionId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual MsUser CreatedByNavigation { get; set; } = null!;

    public virtual JobDescription JobDescription { get; set; } = null!;

    public virtual MsUser? ModifiedByNavigation { get; set; }
}

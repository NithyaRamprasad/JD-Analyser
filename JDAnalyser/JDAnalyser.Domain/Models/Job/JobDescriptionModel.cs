namespace JDAnalyser.Domain.Models.Job
{
    public class JobDescriptionModel
    {
        public int JobDescriptionId { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public IEnumerable<JobSummaryModel> JobSummaries { get; set; }
    }
}

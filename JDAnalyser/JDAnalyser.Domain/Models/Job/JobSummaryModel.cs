namespace JDAnalyser.Domain.Models.Job
{
    public class JobSummaryModel
    {
        public int JobSummaryId { get; set; }

        public string? Summary { get; set; }

        public int JobDescriptionId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}

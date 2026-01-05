using JDAnalyser.Domain.Models.Job;

namespace JDAnalyser.Application.Interfaces.Persistence
{
    public interface IJobAnalysisRepository
    {
        public Task<IEnumerable<JobDescriptionModel>> GetJobDescriptionSummaryList(int userId);
        public Task<JobDescriptionModel> GetJobDescriptionSummary(int? id);
    }
}

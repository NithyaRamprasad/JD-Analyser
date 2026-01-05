using JDAnalyser.Application.Interfaces.Persistence;
using JDAnalyser.Domain.Models.Job;

namespace JDAnalyser.Application.Services.Persistence
{
    public class JDAnalysisService(IJobAnalysisRepository repository)
    {
        private readonly IJobAnalysisRepository _repository = repository;

        public async Task<IEnumerable<JobDescriptionModel>> GetJobDescriptionSummaryList(int userId)
        {
            return await _repository.GetJobDescriptionSummaryList(userId);
        }
    }
}

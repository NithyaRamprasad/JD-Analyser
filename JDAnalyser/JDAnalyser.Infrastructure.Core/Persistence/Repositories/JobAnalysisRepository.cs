using JDAnalyser.Application.Interfaces.Persistence;
using JDAnalyser.Domain.Models.Job;
using JDAnalyser.Infrastructure.Persistence.Persistence.Context;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace JDAnalyser.Infrastructure.Persistence.Persistence.Repositories
{
    public class JobAnalysisRepository(JDAnalyserDbContext jDAnalyserDbContext, IMapper mapper) : IJobAnalysisRepository
    {
        private readonly JDAnalyserDbContext _dbContext = jDAnalyserDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<JobDescriptionModel>> GetJobDescriptionSummaryList(int userId)
        {
            var jd = await _dbContext.JobDescriptions
                .Where(x => x.CreatedBy == userId)
                .Include(x => x.JobSummaries)
                .ToListAsync();

            return _mapper.Map<IEnumerable<JobDescriptionModel>>(jd);
        }

        public async Task<JobDescriptionModel> GetJobDescriptionSummary(int? id)
        {
            var jd = await _dbContext.JobDescriptions
                .Where(x => x.JobDescriptionId == id)
                .Include(x => x.JobSummaries)
                .FirstOrDefaultAsync();

            return _mapper.Map<JobDescriptionModel>(jd);
        }
    }
}
    
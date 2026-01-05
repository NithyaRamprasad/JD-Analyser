using JDAnalyser.Domain.Models.Job;
using JDAnalyser.Infrastructure.Persistence.Entities;
using Mapster;

namespace JDAnalyser.Infrastructure.Persistence.Mapper
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<JobDescription, JobDescriptionModel>();
        }
    }
}

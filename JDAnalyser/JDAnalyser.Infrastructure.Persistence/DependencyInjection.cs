using JDAnalyser.Application.Interfaces.Persistence;
using JDAnalyser.Infrastructure.Persistence.Context;
using JDAnalyser.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JDAnalyser.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<JDAnalyserDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("default")));

            services.AddScoped<IJobAnalysisRepository, JobAnalysisRepository>();

            return services;
        }
    }
}

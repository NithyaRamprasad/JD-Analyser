using JDAnalyser.Application.Interfaces.Cache;
using JDAnalyser.Application.Interfaces.Persistence;
using JDAnalyser.Infrastructure.Cache.Services;
using JDAnalyser.Infrastructure.Persistence.Persistence.Context;
using JDAnalyser.Infrastructure.Persistence.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JDAnalyser.Infrastructure.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreInfrastructure(
            this IServiceCollection services,
            IConfiguration config)
        {
            // persistence
            services.AddDbContext<JDAnalyserDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("default")));

            services.AddScoped<IJobAnalysisRepository, JobAnalysisRepository>();

            // redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config["Redis:ConnectionString"];
                options.InstanceName = "JDAnalyser:";
            });

            services.AddScoped<ISessionService, RedisSessionService>();

            return services;
        }
    }
}

using JDAnalyser.Application.Interfaces.Cache;
using JDAnalyser.Infrastructure.Cache.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JDAnalyser.Infrastructure.Cache
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRedisCache(
            this IServiceCollection services,
            IConfiguration config)
        {
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

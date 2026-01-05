using JDAnalyser.Application.Interfaces.Cache;
using JDAnalyser.Domain.Models.Auth;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace JDAnalyser.Infrastructure.Cache.Services
{
    public class RedisSessionService(IDistributedCache cache) : ISessionService
    {
        private readonly IDistributedCache _cache = cache;

        public async Task<string> CreateAsync(UserSession session)
        {
            var sessionId = Guid.NewGuid().ToString("N");

            var json = JsonSerializer.Serialize(session);

            await _cache.SetStringAsync(
                Key(sessionId),
                json,
                new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                });

            return sessionId;
        }

        public async Task<UserSession?> GetAsync(string sessionId)
        {
            var json = await _cache.GetStringAsync(Key(sessionId));
            return json is null
                ? null
                : JsonSerializer.Deserialize<UserSession>(json);
        }

        public Task RevokeAsync(string sessionId)
            => _cache.RemoveAsync(Key(sessionId));

        private static string Key(string id) => $"session:{id}";
    }
}

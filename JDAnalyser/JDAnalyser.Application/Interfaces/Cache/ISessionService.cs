using JDAnalyser.Domain.Models.Auth;

namespace JDAnalyser.Application.Interfaces.Cache
{
    public interface ISessionService
    {
        Task<string> CreateAsync(UserSession session);
        Task<UserSession?> GetAsync(string sessionId);
        Task RevokeAsync(string sessionId);
    }
}

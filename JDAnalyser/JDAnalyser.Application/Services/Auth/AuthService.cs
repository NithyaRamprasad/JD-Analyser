using JDAnalyser.Application.Interfaces.Cache;
using JDAnalyser.Application.Interfaces.Persistence;
using JDAnalyser.Application.Request.Auth;
using JDAnalyser.Domain.Models.Auth;

namespace JDAnalyser.Application.Services.Auth
{
    public class AuthService(ISessionService sessions, IUserRepository userRepository)
    {
        private readonly ISessionService _sessions = sessions;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<string> GetLoginDetails(LoginRequest request)
        {
            //_userRepository.GetUserDetails(request.Username);

            var sessionId = await _sessions.CreateAsync(
                new UserSession("123", new[] { "Admin" }));

            return sessionId;
        }

        public async Task Logout(string sessionId)
        {
            await _sessions.RevokeAsync(sessionId);
        }
    }
}

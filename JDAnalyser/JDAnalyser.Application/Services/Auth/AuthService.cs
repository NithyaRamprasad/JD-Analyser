using JDAnalyser.Application.Interfaces.Cache;
using JDAnalyser.Application.Interfaces.Persistence;
using JDAnalyser.Application.Request.Auth;
using JDAnalyser.Domain.Models.Auth;
using JDAnalyser.Domain.Models.User;

namespace JDAnalyser.Application.Services.Auth
{
    public class AuthService(ISessionService sessions, IUserRepository userRepository)
    {
        private readonly ISessionService _sessions = sessions;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<string> GetLoginDetails(LoginRequest request)
        {
            UserModel user = await _userRepository.GetUserDetails(request.EmailId);

            var sessionId = await _sessions.CreateAsync(
                new UserSession(user.UserId, new[] { user.RoleName }));

            return sessionId;
        }

        public async Task Logout(string sessionId)
        {
            await _sessions.RevokeAsync(sessionId);
        }
    }
}

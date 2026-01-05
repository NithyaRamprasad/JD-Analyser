using JDAnalyser.Application.Interfaces.Cache;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace JDAnalyser.API.Auth
{
    public class SessionAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISessionService sessions)
        : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        private readonly ISessionService _sessions = sessions;

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // 1️ Read session cookie
            if (!Request.Cookies.TryGetValue("session_id", out var sessionId))
                return AuthenticateResult.NoResult();

            // 2️ Load session from Redis
            var session = await _sessions.GetAsync(sessionId);
            if (session is null)
                return AuthenticateResult.Fail("Invalid session");

            // 3️ Create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, session.UserId)
            };

            foreach (var role in session.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // 4️ Create principal
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            // 5️ Return success
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}

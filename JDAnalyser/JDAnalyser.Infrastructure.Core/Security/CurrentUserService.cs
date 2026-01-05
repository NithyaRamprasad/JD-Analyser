using JDAnalyser.Application.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using System.Security;
using System.Security.Claims;

namespace JDAnalyser.Infrastructure.Core.Security
{
    public class CurrentUserService(IHttpContextAccessor http) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _http = http;

        public bool IsAuthenticated =>
            _http.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public int UserId
        {
            get
            {
                var value = _http.HttpContext?
                    .User?
                    .FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrWhiteSpace(value))
                    throw new UnauthorizedAccessException();

                if (!int.TryParse(value, out var userId))
                    throw new SecurityException("Invalid user id claim");

                return userId;
            }
        }

        public string? Username =>
            _http.HttpContext?.User.Identity?.Name;

        public IReadOnlyCollection<string> Roles =>
            _http.HttpContext?.User
                .FindAll(ClaimTypes.Role)
                .Select(c => c.Value)
                .ToArray()
            ?? Array.Empty<string>();
    }
}

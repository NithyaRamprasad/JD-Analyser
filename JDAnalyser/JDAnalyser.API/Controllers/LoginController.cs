using JDAnalyser.Application.Request.Auth;
using JDAnalyser.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JDAnalyser.API.Controllers
{
    public class LoginController(AuthService service) : Controller
    {
        private readonly AuthService _authService = service;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var sessionId = await _authService.GetLoginDetails(request);

            Response.Cookies.Append(
                "session_id",
                sessionId,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Path = "/",
                    IsEssential = true
                });

            return Ok();
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies.TryGetValue("session_id", out var sessionId))
            {
                await _authService.Logout(sessionId);
                Response.Cookies.Delete("session_id");
            }

            return Ok();
        }
    }
}

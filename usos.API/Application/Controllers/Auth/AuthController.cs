using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.Auth;
using usos.API.Application.Models.Auth;
using usos.API.Configurations;
using usos.API.Seeds;

namespace usos.API.Application.Controllers.Auth
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (userId, email, roleId) = await _authService.Login(request);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, userId),
                new (ClaimTypes.Name, email),
                new (ClaimTypes.Email, email),
                new (ClaimTypes.Role, roleId)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return StatusCode(StatusCodes.Status200OK);
        }
        
        [HttpPost("logout")]
        [HasRoles(RoleSeed.StudentId, RoleSeed.RectorId, RoleSeed.DeaneryWorkerId, RoleSeed.LecturerId)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return StatusCode(StatusCodes.Status200OK);
        }
        
        [HttpPatch("{userId:guid}/password")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SetPassword([FromRoute] Guid userId,
            [FromQuery] string token,
            [FromBody] SetPasswordRequest request)
        {
            await _authService.SetPassword(userId, token, request);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usos.API.Application.IServices.Auth;
using usos.API.Application.Models.Auth;

namespace usos.API.Application.Controllers.User
{
    [ApiController]
    [Route("/api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(CurrentUserResponse))]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(await _authService.GetCurrentUser());
        }
    }
}
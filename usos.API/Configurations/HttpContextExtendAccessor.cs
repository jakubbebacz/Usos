using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace usos.API.Configurations
{
    public class HttpContextExtendAccessor : IHttpContextExtendAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextExtendAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public Guid UserId
        {
            get
            {
                var nameIdentifier = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrWhiteSpace(nameIdentifier) ? Guid.Empty : Guid.Parse(nameIdentifier);
            }
        }
        
        public Guid RoleId
        {
            get
            {
                var role = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
                return string.IsNullOrWhiteSpace(role) ? Guid.Empty : Guid.Parse(role);
            }
        }
    }
}
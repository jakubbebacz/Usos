using Microsoft.AspNetCore.Authorization;

namespace usos.API.Configurations
{
    public class HasRolesAttribute : AuthorizeAttribute
    {
        public HasRolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
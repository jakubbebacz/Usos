using System;

namespace usos.API.Application.Models.Auth
{
    public class CurrentUserResponse
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}
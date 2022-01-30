using System;

namespace usos.API.Configurations
{
    public interface IHttpContextExtendAccessor
    {
        public Guid UserId { get; }
        
        public Guid RoleId { get; }
    }
}
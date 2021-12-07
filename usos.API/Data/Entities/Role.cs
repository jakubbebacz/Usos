using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        
        public string CardId { get; set; }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        
        public ICollection<Application> Application { get; set; }
    }
}
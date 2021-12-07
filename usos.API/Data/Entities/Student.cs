using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public int Term { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public int IndexNumber { get; set; }
        
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int? Semester { get; set; }
        
        public ICollection<Application> Application { get; set; }
    }
}
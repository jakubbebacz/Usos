using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public abstract class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        
        public virtual ICollection<DegreeCourse> DegreeCourses { get; set; }
    }
}
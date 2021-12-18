using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        
        public virtual ICollection<DegreeCourse> DegreeCourses { get; set; }
        
        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}
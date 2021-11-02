using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class DegreeCourse
    {
        public Guid DegreeCourseId { get; set; }

        public Guid DepartmentId { get; set; }
        
        public virtual Department Department { get; set; }

        public Guid DegreeCourseName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
}
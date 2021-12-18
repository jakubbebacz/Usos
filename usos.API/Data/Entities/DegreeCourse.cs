using System;
using System.Collections;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class DegreeCourse
    {
        public Guid DegreeCourseId { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string DegreeCourseName { get; set; }
        
        public ICollection<Subject> Subjects { get; set; }
        
        public virtual ICollection<Group> Groups { get; set; }
    }
}
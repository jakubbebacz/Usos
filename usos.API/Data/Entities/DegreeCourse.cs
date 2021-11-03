using System;

namespace usos.API.Entities
{
    public class DegreeCourse
    {
        public Guid DegreeCourseId { get; set; }

        public Guid DepartmentId { get; set; }
        
        public virtual Department Department { get; set; }

        public string DegreeCourseName { get; set; }
    }
}
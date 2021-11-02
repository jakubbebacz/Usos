using System;

namespace usos.API.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        
        public Guid DegreeCourseId { get; set; }

        public virtual DegreeCourse DegreeCourse { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public int IndexNumber { get; set; }

        public int? Semester { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Group
    {
        public Guid GroupId { get; set; }
        
        public string Name { get; set; }
        
        public Guid DegreeCourseId { get; set; }
        public virtual DegreeCourse DegreeCourse { get; set; }
        
        public int Term { get; set; }

        public ICollection<Student> Students { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
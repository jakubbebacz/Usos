using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Subject
    {
        public Guid SubjectId { get; set; }

        public Guid DegreeCourseId { get; set; }
        public virtual DegreeCourse DegreeCourse { get; set; }
        
        public string SubjectName { get; set; }

        public int SubjectSemester { get; set; }
        public virtual ICollection<LecturerGroup> LecturerGroups { get; set; }
        
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
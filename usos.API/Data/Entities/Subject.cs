using System;

namespace usos.API.Entities
{
    public class Subject
    {
        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Guid DegreeCourseId { get; set; }
        public virtual DegreeCourse DegreeCourse { get; set; }
    }
}
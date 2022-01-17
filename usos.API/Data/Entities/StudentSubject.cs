using System;
using System.Collections;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class StudentSubject
    {
        public Guid StudentSubjectId { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        
        public double Mark { get; set; }
    }
}
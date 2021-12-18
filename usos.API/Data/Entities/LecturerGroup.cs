using System;

namespace usos.API.Entities
{
    public class LecturerGroup
    {
        public Guid LecturerGroupId { get; set; }

        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        
        public Guid LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
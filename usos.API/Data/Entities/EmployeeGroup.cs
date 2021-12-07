using System;

namespace usos.API.Entities
{
    public class EmployeeGroup
    {
        public Guid EmployeeGroupId { get; set; }

        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
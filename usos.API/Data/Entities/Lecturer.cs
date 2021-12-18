using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Lecturer
    {
        public Guid LecturerId { get; set; }
        
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        
        public string CardId { get; set; }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
        
        public virtual ICollection<LecturerGroup> LecturerGroups { get; set; }
        
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
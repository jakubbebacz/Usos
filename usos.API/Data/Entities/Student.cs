using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public int IndexNumber { get; set; }
        
        public int? Semester { get; set; }

        public ICollection<Application> Applications { get; set; }
        
        public ICollection<Questionnaire> Questionnaires { get; set; }
        
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        
    }
}
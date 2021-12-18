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

        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public int IndexNumber { get; set; }
        
        public int? Semester { get; set; }

        public ICollection<Application> Application { get; set; }
        
        public ICollection<Questionnaire> Questionnaire { get; set; }
        
    }
}
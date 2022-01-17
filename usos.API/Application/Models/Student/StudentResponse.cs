using System;

namespace usos.API.Application.Models
{
    public class StudentResponse
    {
        public Guid StudentId { get; set; }
        
        public Guid GroupId { get; set; }
        
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        
        public int IndexNumber { get; set; }
    }
}
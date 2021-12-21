using System;

namespace usos.API.Application.Models.Lecturer
{
    public class LecturerRequest
    {
        public Guid DepartmentId { get; set; }
        
        public string CardId { get; set; }
        
        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
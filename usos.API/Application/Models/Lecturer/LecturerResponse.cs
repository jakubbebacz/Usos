using System;

namespace usos.API.Application.Models.Lecturer
{
    public class LecturerResponse
    {
        public Guid LecturerId { get; set; }
        
        public Guid DepartmentId { get; set; }

        public string CardId { get; set; }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
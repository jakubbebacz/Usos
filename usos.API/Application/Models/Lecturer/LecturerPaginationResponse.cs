using System;

namespace usos.API.Application.Models.Lecturer
{
    public class LecturerPaginationResponse
    {
        public Guid LecturerId { get; set; }
        
        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }
    }
}
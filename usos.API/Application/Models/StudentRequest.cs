using System;

namespace usos.API.Application.Models
{
    public class StudentRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public int IndexNumber { get; set; }

    }
}
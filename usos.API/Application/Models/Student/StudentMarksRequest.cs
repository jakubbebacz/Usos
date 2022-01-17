using System;

namespace usos.API.Application.Models
{
    public class StudentMarksRequest
    {
        public Guid StudentId { get; set; }
        
        public Guid SubjectId { get; set; }

        public double Mark { get; set; }
    }
}
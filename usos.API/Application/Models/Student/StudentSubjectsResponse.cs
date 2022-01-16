using System.Collections.Generic;

namespace usos.API.Application.Models
{
    public class StudentSubjectsResponse
    {
        public IList<Entities.Subject> Subjects { get; set; }
    }
}
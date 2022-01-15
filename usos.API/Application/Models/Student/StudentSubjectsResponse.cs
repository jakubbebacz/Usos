using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Application.Models
{
    public class StudentSubjectsResponse
    {
        public IList<Subject> Subjects { get; set; }
    }
}
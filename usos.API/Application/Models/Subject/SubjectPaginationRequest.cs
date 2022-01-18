using System;

namespace usos.API.Application.Models.Subject
{
    public class SubjectPaginationRequest : PaginationRequest
    {
        public string Phrase { get; set; }
        public Guid? DegreeCourseId { get; set; }
    }
}
using System;

namespace usos.API.Application.Models.Subject
{
    public class SubjectPaginationRequest : PaginationRequest
    {
        public Guid? DegreeCourseId { get; set; }
    }
}
using System;

namespace usos.API.Application.Models.Lecturer
{
    public class LecturerPaginationRequest : PaginationRequest
    {
        public string Phrase { get; set; }
        
        public Guid? DepartmentId { get; set; }
    }
}
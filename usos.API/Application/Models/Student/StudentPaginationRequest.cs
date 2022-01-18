using System;

namespace usos.API.Application.Models
{
    public class StudentPaginationRequest : PaginationRequest
    {
        public string Phrase { get; set; }
        
        public Guid? GroupId { get; set; }
    }
}
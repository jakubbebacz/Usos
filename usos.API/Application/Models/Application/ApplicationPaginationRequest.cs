using System;

namespace usos.API.Application.Models.Application
{
    public class ApplicationPaginationRequest: PaginationRequest
    {
        public Guid? StudentId { get; set; }
    }
}
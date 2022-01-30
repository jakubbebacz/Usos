using System;

namespace usos.API.Application.Models.Application
{
    public class ApplicationPaginationResponse
    {
        public Guid ApplicationId { get; set; }
        
        public Guid StudentId { get; set; }

        public Guid RecipientId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool IsApproved { get; set; }
    }
}
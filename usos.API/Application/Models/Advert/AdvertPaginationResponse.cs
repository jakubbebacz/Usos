using System;

namespace usos.API.Application.Models
{
    public class AdvertPaginationResponse
    {
        public Guid AdvertId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }
        
        public DateTime Date { get; set; }
    }
}
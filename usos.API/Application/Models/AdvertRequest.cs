using System;

namespace usos.API.Application.Models
{
    public class AdvertRequest
    {
        public Guid DeaneryWorkerId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }
        
        public string Date { get; set; }
    }
}
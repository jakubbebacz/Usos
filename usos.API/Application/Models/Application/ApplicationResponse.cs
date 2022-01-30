using System;

namespace usos.API.Application.Models.Application
{
    public class ApplicationResponse
    {
        public Guid studentId { get; set; }

        public Guid reciepentId { get; set; }

        public string title { get; set; }

        public string note { get; set; }

        public bool isAccepted { get; set; }
    }
}
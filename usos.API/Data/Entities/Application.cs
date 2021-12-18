using System;

namespace usos.API.Entities
{
    public class Application
    {
        public Guid ApplicationId { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public Guid Recipent { get; set; }
        
        public string Title { get; set; }

        public string Note { get; set; }
        
        public bool IsAccepted { get; set; }
    }
}
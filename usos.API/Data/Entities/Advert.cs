using System;

namespace usos.API.Entities
{
    public class Advert
    {
        public Guid AdvertId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }
        
        public DateTime Data { get; set; }
    }
}
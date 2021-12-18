using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class DeaneryWorker
    {
        public Guid DeaneryWorkerId { get; set; }
        
        public string CardId { get; set; }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
        
        public ICollection<Advert> Advert { get; set; }
    }
}
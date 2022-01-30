using System;
using System.Collections.Generic;

namespace usos.API.Entities
{
    public class Rector
    {
        public Guid RectorId { get; set; }
        
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        
        public string CardId { get; set; }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Password { get; set; }
        
        public bool IsPasswordChangeRequired { get; set; }
        
        public string Email { get; set; }
    }
}
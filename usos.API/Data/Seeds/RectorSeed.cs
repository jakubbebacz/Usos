using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class RectorSeed
    {
        public static readonly Guid RectorId = Guid.Parse("fa411b2a-47e3-4911-a726-7b52764df9cb");
        
        public static IEnumerable<Rector> Seed()
        {
            return new List<Rector>
            {
                new()
                {
                    RectorId = RectorId,
                    CardId = "000000",
                    FirstName = "Admin",
                    Surname = "Admin",
                    PhoneNumber = "000000000",
                    Email = "admin@admin.com"
                },
            };
        }
    }
}
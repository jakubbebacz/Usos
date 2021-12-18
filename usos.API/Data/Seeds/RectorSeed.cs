using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class RectorSeed
    {
        public static readonly Guid RectorId = Guid.NewGuid();
        
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
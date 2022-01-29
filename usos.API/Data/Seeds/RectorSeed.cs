using System;
using System.Collections.Generic;
using usos.API.Entities;

namespace usos.API.Seeds
{
    public class RectorSeed
    {
        public static readonly Guid RectorId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
        
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
                    Email = "admin@admin.com",
                    Password = "d9c9bd1ff7f42891f5bf22a4ef4c6ad8cd5fc539dbd86844030288bf027acaef",
                    IsPasswordChangeRequired = false
                }
            };
        }
    }
}
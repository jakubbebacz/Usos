using System;
using Microsoft.EntityFrameworkCore;
using usos.API;

namespace UnitTests
{
    public class DbContextConfigBase
    {
        protected readonly UsosDbContext _context;
        
        public DbContextConfigBase()
        {
            var options = new DbContextOptionsBuilder<UsosDbContext>()
                .UseInMemoryDatabase(databaseName: $"usos-{Guid.NewGuid()}")
                .Options;
            
            _context = new UsosDbContext(options);
        }
    }
}
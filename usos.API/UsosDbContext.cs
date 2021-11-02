using Microsoft.EntityFrameworkCore;
using usos.API.Entities;

namespace usos.API
{
    public class UsosDbContext : DbContext
    {
        public UsosDbContext(DbContextOptions<UsosDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<DegreeCourse> DegreeCourse { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
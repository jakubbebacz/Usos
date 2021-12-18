using Microsoft.EntityFrameworkCore;
using usos.API.Entities;

namespace usos.API
{
    public class UsosDbContext : DbContext
    {
        public UsosDbContext(DbContextOptions<UsosDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<DegreeCourse> DegreeCourse { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Advert> Advert { get; set; }
        public DbSet<Entities.Application> Application { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Rector> Rector { get; set; }
        public DbSet<DeaneryWorker> DeaneryWorker { get; set; }
        public DbSet<LecturerGroup> LecturerGroup { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }
        public DbSet<Subject> Subject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
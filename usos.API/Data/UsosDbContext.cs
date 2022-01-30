using Microsoft.EntityFrameworkCore;
using usos.API.Configurations;
using usos.API.Entities;

namespace usos.API
{
    public class UsosDbContext : DbContext
    {
        private readonly IHttpContextExtendAccessor _httpContextExtendAccessor;

        public UsosDbContext(DbContextOptions<UsosDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public UsosDbContext(DbContextOptions<UsosDbContext> dbContextOptions,
            IHttpContextExtendAccessor httpContextExtendAccessor) : base(dbContextOptions)
        {
            _httpContextExtendAccessor = httpContextExtendAccessor;
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DegreeCourse> DegreeCourse { get; set; }
        public virtual  DbSet<Student> Student { get; set; }
        public virtual DbSet<Advert> Advert { get; set; }
        public virtual DbSet<Entities.Application> Application { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<Rector> Rector { get; set; }
        public virtual DbSet<DeaneryWorker> DeaneryWorker { get; set; }
        public virtual DbSet<LecturerGroup> LecturerGroup { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Questionnaire> Questionnaire { get; set; }
        public virtual DbSet<StudentSubject> StudentSubject { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
               
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
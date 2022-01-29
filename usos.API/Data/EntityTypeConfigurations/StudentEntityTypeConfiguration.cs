using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);
            builder.Property(x => x.StudentId)
                .IsRequired();
            
            builder.HasOne(x => x.Role)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();
            
            builder.HasOne(x => x.Group)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GroupId)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Surname)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(256);

            builder.Property(x => x.IsPasswordChangeRequired)
                .IsRequired();

            builder.Property(x => x.IndexNumber)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Semester)
                .HasMaxLength(1); 
        }
    }
}
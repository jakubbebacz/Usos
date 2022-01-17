using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class StudentSubjectEntityTypeConfiguration :IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(x => x.StudentSubjectId);
            builder.Property(x => x.StudentSubjectId)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.SubjectId)
                .IsRequired();
            
            builder.Property(x => x.Mark)
                .HasMaxLength(100);
        }
    }
}
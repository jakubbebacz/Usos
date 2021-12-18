using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class SubjectEntityTypeConfiguration :IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubjectId);
            builder.Property(x => x.SubjectId)
                .IsRequired();
            
            builder.HasOne(x => x.DegreeCourse)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.DegreeCourseId);

            builder.Property(x => x.SubjectName)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
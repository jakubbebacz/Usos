using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;
using usos.API.Seeds;

namespace usos.API.EntityTypeConfigurations
{
    public class DegreeCourseEntityTypeConfiguration : IEntityTypeConfiguration<DegreeCourse>
    {
        public void Configure(EntityTypeBuilder<DegreeCourse> builder)
        {
            builder.HasKey(x => x.DegreeCourseId);
            builder.Property(x => x.DegreeCourseId)
                .IsRequired();
            
            builder.HasOne(x => x.Department)
                .WithMany(x => x.DegreeCourses)
                .HasForeignKey(x => x.DepartmentId);
            
            builder.Property(x => x.DegreeCourseName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.HasData(DegreeCourseSeed.Seed());
        }
    }
}
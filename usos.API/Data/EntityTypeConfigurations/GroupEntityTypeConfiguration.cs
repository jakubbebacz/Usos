using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;
using usos.API.Seeds;

namespace usos.API.EntityTypeConfigurations
{
    public class GroupEntityTypeConfiguration :IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.GroupId);
            builder.Property(x => x.GroupId)
                .IsRequired();
            
            builder.HasOne(x => x.DegreeCourse)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.DegreeCourseId);
            
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Term)
                .HasMaxLength(2)
                .IsRequired();
            
            builder.HasData(GroupSeed.Seed());
        }
    }
}
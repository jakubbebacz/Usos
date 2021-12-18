using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class LecturerGroupEntityTypeConfiguration :IEntityTypeConfiguration<LecturerGroup>
    {
        public void Configure(EntityTypeBuilder<LecturerGroup> builder)
        {
            builder.HasKey(x => x.LecturerGroupId);
            builder.Property(x => x.LecturerGroupId)
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany(x => x.LecturerGroups)
                .HasForeignKey(x => x.GroupId)
                .IsRequired();

            builder.HasOne(x => x.Lecturer)
                .WithMany(x => x.LecturerGroups)
                .HasForeignKey(x => x.LecturerId)
                .IsRequired();
            
            builder.HasOne(x => x.Subject)
                .WithMany(x => x.LecturerGroups)
                .HasForeignKey(x => x.SubjectId)
                .IsRequired();
        }
    }
}
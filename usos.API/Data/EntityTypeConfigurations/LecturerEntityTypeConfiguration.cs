using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class LecturerEntityTypeConfiguration :IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.HasKey(x => x.LecturerId);
            builder.Property(x => x.LecturerId)
                .IsRequired();
            
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Lecturers)
                .HasForeignKey(x => x.DepartmentId);
            
            builder.Property(x => x.CardId)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.FirstName)
                .HasMaxLength(1000)
                .IsRequired();
            
            builder.Property(x => x.Surname)
                .IsRequired();
            
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
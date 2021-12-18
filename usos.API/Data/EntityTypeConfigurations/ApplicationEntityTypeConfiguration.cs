using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class ApplicationEntityTypeConfiguration :IEntityTypeConfiguration<Entities.Application>
    {
        public void Configure(EntityTypeBuilder<Entities.Application> builder)
        {
            builder.HasKey(x => x.ApplicationId);
            builder.Property(x => x.ApplicationId)
                .IsRequired();
            
            builder.HasOne(x => x.Student)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.StudentId);
            
            builder.Property(x => x.Recipent)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(x => x.Note)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.IsAccepted)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class DeaneryWorkerEntityTypeConfiguration :IEntityTypeConfiguration<DeaneryWorker>
    {
        public void Configure(EntityTypeBuilder<DeaneryWorker> builder)
        {
            builder.HasKey(x => x.DeaneryWorkerId);
            builder.Property(x => x.DeaneryWorkerId)
                .IsRequired();

            builder.Property(x => x.CardId)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(x => x.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(x => x.Password)
                .HasMaxLength(256);

            builder.Property(x => x.IsPasswordChangeRequired)
                .IsRequired();
        }
    }
}
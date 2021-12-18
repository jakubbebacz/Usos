using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class AdvertEntityTypeConfiguration :IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(x => x.AdvertId);
            builder.Property(x => x.AdvertId)
                .IsRequired();
            
            builder.HasOne(x => x.DeaneryWorker)
                .WithMany(x => x.Adverts)
                .HasForeignKey(x => x.DeaneryWorkerId);
            
            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Note)
                .HasMaxLength(1000)
                .IsRequired();
            
            builder.Property(x => x.Date)
                .IsRequired();
        }
    }
}
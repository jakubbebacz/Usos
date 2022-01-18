using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;
using usos.API.Seeds;

namespace usos.API.EntityTypeConfigurations
{
    public class RectorEntityTypeConfiguration :IEntityTypeConfiguration<Rector>
    {
        public void Configure(EntityTypeBuilder<Rector> builder)
        {
            builder.HasKey(x => x.RectorId);
            builder.Property(x => x.RectorId)
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
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(x => x.Password)
                .HasMaxLength(256);

            builder.HasData(RectorSeed.Seed());
        }
    }
}
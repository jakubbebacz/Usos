using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;
using usos.API.Seeds;

namespace usos.API.EntityTypeConfigurations
{
    public class  RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.RoleId)
                .IsRequired();

            builder.Property(x => x.RoleName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(RoleSeed.Seed());
        }
    }
}
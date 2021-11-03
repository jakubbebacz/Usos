using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;
using usos.API.Seeds;

namespace usos.API.EntityTypeConfigurations
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId)
                .IsRequired();
            
            builder.Property(x => x.DepartmentName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(DepartmentSeed.Seed());
        }
    }
}
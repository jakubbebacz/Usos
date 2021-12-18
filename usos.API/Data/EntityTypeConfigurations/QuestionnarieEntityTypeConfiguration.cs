using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usos.API.Entities;

namespace usos.API.EntityTypeConfigurations
{
    public class QuestionnaireEntityTypeConfiguration :IEntityTypeConfiguration<Questionnaire>
    {
        public void Configure(EntityTypeBuilder<Questionnaire> builder)
        {
            builder.HasKey(x => x.QuestionnaireId);
            builder.Property(x => x.QuestionnaireId)
                .IsRequired();
            
            builder.HasOne(x => x.Student)
                .WithMany(x => x.Questionnaires)
                .HasForeignKey(x => x.StudentId);
            
            builder.HasOne(x => x.Lecturer)
                .WithMany(x => x.Questionnaires)
                .HasForeignKey(x => x.LecturerId);

            builder.Property(x => x.Note)
                .HasMaxLength(1000)
                .IsRequired();
            
            builder.Property(x => x.Rating)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
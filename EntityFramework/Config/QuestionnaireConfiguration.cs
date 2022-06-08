using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Models;

namespace Hospital.EntityFramework.Config
{
    public class QuestionnaireConfiguration : IEntityTypeConfiguration<Questionnaire>
    {
        public void Configure(EntityTypeBuilder<Questionnaire> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasMany(q => q.Questions)
                .WithOne(q => q.Questionnaire)
                .HasForeignKey(q => q.QuestionnaireId);
        }
    }
}


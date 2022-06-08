using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Models;

namespace Hospital.EntityFramework.Config
{
    public class MedcardConfiguration : IEntityTypeConfiguration<Medcard>
    {
        public void Configure(EntityTypeBuilder<Medcard> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Medpolis).IsRequired().HasMaxLength(30);
            builder.Property(m => m.Snils).IsRequired().HasMaxLength(30);
            builder.Property(m => m.Passport).IsRequired().HasMaxLength(40);
            builder.Property(m => m.DateOfBirth).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");

            builder.HasMany(m => m.Requests)
                .WithOne(r => r.Medcard)
                .HasForeignKey(r => r.MedcardId);
        }
    }
}



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Models;

namespace Hospital.EntityFramework.Config
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Room).IsRequired().HasMaxLength(7);
            builder.Property(d => d.Spec).IsRequired().HasMaxLength(30);
            builder.Property(d => d.Address).IsRequired().HasMaxLength(100);

            builder.HasMany(d => d.Requests)
                .WithOne(r => r.Doctor)
                .HasForeignKey(r => r.DoctorId);
        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Models;

namespace Hospital.EntityFramework.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Phone).IsRequired().HasMaxLength(25);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(40);
            builder.Property(u => u.Key).IsRequired();
            builder.Property(u => u.Role).IsRequired().HasDefaultValue(Role.Patient);
        }
    }
}



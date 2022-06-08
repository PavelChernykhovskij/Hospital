using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Models;

namespace Hospital.EntityFramework.Config
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Comment).IsRequired().HasMaxLength(322);
            builder.Property(r => r.Status).IsRequired().HasDefaultValue(Status.UnderСonsideration);
            builder.Property(r => r.DateOfVisit).IsRequired().HasMaxLength(28).HasColumnType("datetime2(2)");
        }
    }
}

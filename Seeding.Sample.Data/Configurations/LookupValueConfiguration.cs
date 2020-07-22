using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seeding.Sample.Data.Models;

namespace Seeding.Sample.Data.Configurations
{
    public class LookupValueConfiguration : IEntityTypeConfiguration<LookupValue>
    {
        public void Configure(EntityTypeBuilder<LookupValue> builder)
        {
            builder.ToTable("LookupValues");

            builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UseIdentityColumn(1, 1);

            builder.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seeding.Sample.Data.Models;

namespace Seeding.Sample.Data.Configurations
{
    public class LookupTypeConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.ToTable("LookupTypes");

            builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .UseIdentityColumn(1, 1);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(t => t.LookupValues)
                .WithOne(v => v.LookupType)
                .HasForeignKey(v => v.LookupTypeId);
        }
    }
}

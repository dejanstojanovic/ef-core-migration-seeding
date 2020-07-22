using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seeding.Sample.Data.Configurations;
using Seeding.Sample.Data.Models;
using System.IO;

namespace Seeding.Sample.Data
{
    public class SampleDatabaseContext : DbContext
    {
        public SampleDatabaseContext() : base() { }

        public SampleDatabaseContext(DbContextOptions<SampleDatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LookupTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LookupValueConfiguration());
        }

        public virtual DbSet<LookupType> LookupTypes { get; set; }
        public virtual DbSet<LookupValue> LookupValues { get; set; }

        internal static SampleDatabaseContext CreateContext()
        {
            return new SampleDatabaseContext(new DbContextOptionsBuilder<SampleDatabaseContext>().UseSqlServer(
                 new ConfigurationBuilder()
                     .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
                     .AddEnvironmentVariables()
                     .Build()
                     .GetConnectionString("SampleDatabase")
                 ).Options);
        }
    }
}

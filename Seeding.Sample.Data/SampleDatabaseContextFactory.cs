using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Seeding.Sample.Data
{
    public class SampleDatabaseContextFactory : IDesignTimeDbContextFactory<SampleDatabaseContext>
    {
        public SampleDatabaseContext CreateDbContext(string[] args)
        {
            var dbContext = SampleDatabaseContext.CreateContext();
            dbContext.Database.Migrate();
            return dbContext;
        }
    }
}

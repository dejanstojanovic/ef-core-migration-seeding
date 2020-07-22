using Microsoft.EntityFrameworkCore.Migrations;
using Seeding.Sample.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Seeding.Sample.Data.Migrations
{
    public partial class Initial_Lookup_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var databaseContext = SampleDatabaseContext.CreateContext())
            {
                databaseContext.LookupTypes.AddRange(
                    new List<LookupType>() {
                        new LookupType()
                            {
                                Name = "ProductTypes",
                                LookupValues = new List<LookupValue>()
                                {
                                    new LookupValue(){ Value="Laptop" },
                                    new LookupValue(){ Value="Monitor" },
                                    new LookupValue(){ Value="Mouse" },
                                    new LookupValue(){ Value="Keyboard" }
                                }
                            }
                    });

                databaseContext.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var databaseContext = SampleDatabaseContext.CreateContext())
            {
                databaseContext.LookupTypes.Remove(databaseContext.LookupTypes.SingleOrDefault(t => t.Name == "ProductTypes"));
                databaseContext.SaveChanges();
            }
        }
    }
}

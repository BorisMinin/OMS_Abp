using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OMS_Demo_Sample.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OMS_Demo_SampleDbContextFactory : IDesignTimeDbContextFactory<OMS_Demo_SampleDbContext>
{
    public OMS_Demo_SampleDbContext CreateDbContext(string[] args)
    {
        OMS_Demo_SampleEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OMS_Demo_SampleDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new OMS_Demo_SampleDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OMS_Demo_Sample.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
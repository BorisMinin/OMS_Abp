using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OMS_Demo_Sample.Data;
using Volo.Abp.DependencyInjection;

namespace OMS_Demo_Sample.EntityFrameworkCore;

public class EntityFrameworkCoreOMS_Demo_SampleDbSchemaMigrator
    : IOMS_Demo_SampleDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOMS_Demo_SampleDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the OMS_Demo_SampleDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OMS_Demo_SampleDbContext>()
            .Database
            .MigrateAsync();
    }
}

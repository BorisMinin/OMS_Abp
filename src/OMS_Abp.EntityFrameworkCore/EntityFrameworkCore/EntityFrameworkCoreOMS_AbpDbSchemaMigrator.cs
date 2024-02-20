using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OMS_Abp.Data;
using Volo.Abp.DependencyInjection;

namespace OMS_Abp.EntityFrameworkCore;

public class EntityFrameworkCoreOMS_AbpDbSchemaMigrator
    : IOMS_AbpDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOMS_AbpDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the OMS_AbpDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OMS_AbpDbContext>()
            .Database
            .MigrateAsync();
    }
}

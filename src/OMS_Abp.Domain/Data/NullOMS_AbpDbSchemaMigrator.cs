using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OMS_Abp.Data;

/* This is used if database provider does't define
 * IOMS_AbpDbSchemaMigrator implementation.
 */
public class NullOMS_AbpDbSchemaMigrator : IOMS_AbpDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OMS_Demo_Sample.Data;

/* This is used if database provider does't define
 * IOMS_Demo_SampleDbSchemaMigrator implementation.
 */
public class NullOMS_Demo_SampleDbSchemaMigrator : IOMS_Demo_SampleDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

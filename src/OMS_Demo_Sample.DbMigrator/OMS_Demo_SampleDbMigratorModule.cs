using OMS_Demo_Sample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OMS_Demo_Sample.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OMS_Demo_SampleEntityFrameworkCoreModule),
    typeof(OMS_Demo_SampleApplicationContractsModule)
    )]
public class OMS_Demo_SampleDbMigratorModule : AbpModule
{
}

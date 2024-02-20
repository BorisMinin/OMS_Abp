using OMS_Abp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OMS_Abp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OMS_AbpEntityFrameworkCoreModule),
    typeof(OMS_AbpApplicationContractsModule)
    )]
public class OMS_AbpDbMigratorModule : AbpModule
{
}

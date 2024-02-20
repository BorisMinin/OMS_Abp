using Volo.Abp.Modularity;

namespace OMS_Abp;

[DependsOn(
    typeof(OMS_AbpApplicationModule),
    typeof(OMS_AbpDomainTestModule)
    )]
public class OMS_AbpApplicationTestModule : AbpModule
{

}

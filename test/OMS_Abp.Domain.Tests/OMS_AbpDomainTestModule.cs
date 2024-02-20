using OMS_Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OMS_Abp;

[DependsOn(
    typeof(OMS_AbpEntityFrameworkCoreTestModule)
    )]
public class OMS_AbpDomainTestModule : AbpModule
{

}

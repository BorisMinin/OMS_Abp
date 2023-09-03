using OMS_Demo_Sample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OMS_Demo_Sample;

[DependsOn(
    typeof(OMS_Demo_SampleEntityFrameworkCoreTestModule)
    )]
public class OMS_Demo_SampleDomainTestModule : AbpModule
{

}

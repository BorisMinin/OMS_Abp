using Volo.Abp.Modularity;

namespace OMS_Demo_Sample;

[DependsOn(
    typeof(OMS_Demo_SampleApplicationModule),
    typeof(OMS_Demo_SampleDomainTestModule)
    )]
public class OMS_Demo_SampleApplicationTestModule : AbpModule
{

}

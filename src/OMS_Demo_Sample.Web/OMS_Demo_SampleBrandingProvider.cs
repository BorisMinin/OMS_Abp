using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace OMS_Demo_Sample.Web;

[Dependency(ReplaceServices = true)]
public class OMS_Demo_SampleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "OMS_Demo_Sample";
}

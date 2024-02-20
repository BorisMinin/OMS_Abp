using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace OMS_Abp.Web;

[Dependency(ReplaceServices = true)]
public class OMS_AbpBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "OMS_Abp";
}

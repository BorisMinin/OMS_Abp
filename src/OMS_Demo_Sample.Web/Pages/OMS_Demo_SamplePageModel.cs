using OMS_Demo_Sample.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace OMS_Demo_Sample.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class OMS_Demo_SamplePageModel : AbpPageModel
{
    protected OMS_Demo_SamplePageModel()
    {
        LocalizationResourceType = typeof(OMS_Demo_SampleResource);
    }
}

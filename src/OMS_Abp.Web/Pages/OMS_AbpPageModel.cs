using OMS_Abp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace OMS_Abp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class OMS_AbpPageModel : AbpPageModel
{
    protected OMS_AbpPageModel()
    {
        LocalizationResourceType = typeof(OMS_AbpResource);
    }
}

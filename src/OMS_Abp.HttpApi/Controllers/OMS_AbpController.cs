using OMS_Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OMS_Abp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OMS_AbpController : AbpControllerBase
{
    protected OMS_AbpController()
    {
        LocalizationResource = typeof(OMS_AbpResource);
    }
}

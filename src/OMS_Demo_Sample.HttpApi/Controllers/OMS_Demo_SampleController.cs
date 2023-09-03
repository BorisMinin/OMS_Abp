using OMS_Demo_Sample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OMS_Demo_Sample.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OMS_Demo_SampleController : AbpControllerBase
{
    protected OMS_Demo_SampleController()
    {
        LocalizationResource = typeof(OMS_Demo_SampleResource);
    }
}

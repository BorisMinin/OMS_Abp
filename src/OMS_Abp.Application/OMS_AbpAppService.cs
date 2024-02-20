using System;
using System.Collections.Generic;
using System.Text;
using OMS_Abp.Localization;
using Volo.Abp.Application.Services;

namespace OMS_Abp;

/* Inherit your application services from this class.
 */
public abstract class OMS_AbpAppService : ApplicationService
{
    protected OMS_AbpAppService()
    {
        LocalizationResource = typeof(OMS_AbpResource);
    }
}

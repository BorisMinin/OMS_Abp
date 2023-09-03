using System;
using System.Collections.Generic;
using System.Text;
using OMS_Demo_Sample.Localization;
using Volo.Abp.Application.Services;

namespace OMS_Demo_Sample;

/* Inherit your application services from this class.
 */
public abstract class OMS_Demo_SampleAppService : ApplicationService
{
    protected OMS_Demo_SampleAppService()
    {
        LocalizationResource = typeof(OMS_Demo_SampleResource);
    }
}

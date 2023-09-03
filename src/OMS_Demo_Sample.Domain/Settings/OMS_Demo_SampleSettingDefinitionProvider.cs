using Volo.Abp.Settings;

namespace OMS_Demo_Sample.Settings;

public class OMS_Demo_SampleSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OMS_Demo_SampleSettings.MySetting1));
    }
}

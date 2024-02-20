using Volo.Abp.Settings;

namespace OMS_Abp.Settings;

public class OMS_AbpSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OMS_AbpSettings.MySetting1));
    }
}

using OMS_Demo_Sample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OMS_Demo_Sample.Permissions;

public class OMS_Demo_SamplePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OMS_Demo_SamplePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(OMS_Demo_SamplePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OMS_Demo_SampleResource>(name);
    }
}

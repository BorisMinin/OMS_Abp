using OMS_Abp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OMS_Abp.Permissions;

public class OMS_AbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OMS_AbpPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(OMS_AbpPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OMS_AbpResource>(name);
    }
}

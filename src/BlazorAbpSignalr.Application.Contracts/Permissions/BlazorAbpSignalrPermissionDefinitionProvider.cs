using BlazorAbpSignalr.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlazorAbpSignalr.Permissions;

public class BlazorAbpSignalrPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BlazorAbpSignalrPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlazorAbpSignalrPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlazorAbpSignalrResource>(name);
    }
}

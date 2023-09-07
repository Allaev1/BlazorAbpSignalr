using Volo.Abp.Settings;

namespace BlazorAbpSignalr.Settings;

public class BlazorAbpSignalrSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BlazorAbpSignalrSettings.MySetting1));
    }
}

using BlazorAbpSignalr.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BlazorAbpSignalr.Blazor;

public abstract class BlazorAbpSignalrComponentBase : AbpComponentBase
{
    protected BlazorAbpSignalrComponentBase()
    {
        LocalizationResource = typeof(BlazorAbpSignalrResource);
    }
}

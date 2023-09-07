using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlazorAbpSignalr.Blazor;

[Dependency(ReplaceServices = true)]
public class BlazorAbpSignalrBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlazorAbpSignalr";
}

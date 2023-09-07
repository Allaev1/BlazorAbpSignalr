using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlazorAbpSignalr;

[Dependency(ReplaceServices = true)]
public class BlazorAbpSignalrBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlazorAbpSignalr";
}

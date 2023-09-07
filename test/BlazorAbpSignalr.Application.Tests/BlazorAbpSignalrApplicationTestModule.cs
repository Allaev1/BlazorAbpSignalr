using Volo.Abp.Modularity;

namespace BlazorAbpSignalr;

[DependsOn(
    typeof(BlazorAbpSignalrApplicationModule),
    typeof(BlazorAbpSignalrDomainTestModule)
    )]
public class BlazorAbpSignalrApplicationTestModule : AbpModule
{

}

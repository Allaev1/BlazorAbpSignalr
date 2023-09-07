using BlazorAbpSignalr.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlazorAbpSignalr;

[DependsOn(
    typeof(BlazorAbpSignalrEntityFrameworkCoreTestModule)
    )]
public class BlazorAbpSignalrDomainTestModule : AbpModule
{

}

using BlazorAbpSignalr.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BlazorAbpSignalr.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BlazorAbpSignalrEntityFrameworkCoreModule),
    typeof(BlazorAbpSignalrApplicationContractsModule)
    )]
public class BlazorAbpSignalrDbMigratorModule : AbpModule
{
}

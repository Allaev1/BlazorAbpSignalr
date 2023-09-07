using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlazorAbpSignalr.Data;

/* This is used if database provider does't define
 * IBlazorAbpSignalrDbSchemaMigrator implementation.
 */
public class NullBlazorAbpSignalrDbSchemaMigrator : IBlazorAbpSignalrDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

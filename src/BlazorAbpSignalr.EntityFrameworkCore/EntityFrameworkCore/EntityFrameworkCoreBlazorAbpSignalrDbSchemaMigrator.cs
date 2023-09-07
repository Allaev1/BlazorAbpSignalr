using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorAbpSignalr.Data;
using Volo.Abp.DependencyInjection;

namespace BlazorAbpSignalr.EntityFrameworkCore;

public class EntityFrameworkCoreBlazorAbpSignalrDbSchemaMigrator
    : IBlazorAbpSignalrDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBlazorAbpSignalrDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BlazorAbpSignalrDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BlazorAbpSignalrDbContext>()
            .Database
            .MigrateAsync();
    }
}

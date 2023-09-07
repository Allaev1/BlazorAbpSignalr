using System.Threading.Tasks;

namespace BlazorAbpSignalr.Data;

public interface IBlazorAbpSignalrDbSchemaMigrator
{
    Task MigrateAsync();
}

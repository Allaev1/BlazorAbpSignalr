using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace BlazorAbpSinglar.NotificationSender
{
    [DependsOn(typeof(AbpAspNetCoreSignalRModule))]
    public class BlazorAbpSignalrNotificationSenderModule : AbpModule
    {

    }
}
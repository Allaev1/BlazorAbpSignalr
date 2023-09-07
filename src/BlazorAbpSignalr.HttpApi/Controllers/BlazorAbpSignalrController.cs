using BlazorAbpSignalr.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlazorAbpSignalr.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlazorAbpSignalrController : AbpControllerBase
{
    protected BlazorAbpSignalrController()
    {
        LocalizationResource = typeof(BlazorAbpSignalrResource);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BlazorAbpSignalr.Localization;
using Volo.Abp.Application.Services;

namespace BlazorAbpSignalr;

/* Inherit your application services from this class.
 */
public abstract class BlazorAbpSignalrAppService : ApplicationService
{
    protected BlazorAbpSignalrAppService()
    {
        LocalizationResource = typeof(BlazorAbpSignalrResource);
    }
}

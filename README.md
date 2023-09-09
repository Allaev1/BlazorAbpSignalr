# BlazorAbpSignalr
Tutorial on how integrate module with SignalR in Blazor application that is built on ABP framework

1. Create Blazor project with this CLI command - `abp new Acme.BookStore -t app-pro -u blazor`

2. You can run application by following this instructions - https://docs.abp.io/en/commercial/latest/getting-started-running-solution?UI=Blazor&DB=EF&Tiered=No#getting-started

3. Add class library and name it `YourProjectName.NotificationSender`

4. Add `Volo.Abp.Core` and `Volo.Abp.AspNetCore.SignalR` NuGet packages

5. Add module class with such name - `(NameOfYourProject)NotificationSenderModule`. In my case this is `BlazorAbpSignalrNotificationSender`

6. Inherit class from `AbpModule`. Your class should look like this:
```
using Volo.Abp.Modularity;

namespace BlazorAbpSinglar.NotificationSender
{
    public class BlazorAbpSignalrNotificationSenderModule : AbpModule
    {

    }
}
```

7. Add dependency on Signalr module. Your class will be look this:
```
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace BlazorAbpSinglar.NotificationSender
{
    [DependsOn(typeof(AbpAspNetCoreSignalRModule))]
    public class BlazorAbpSignalrNotificationSenderModule : AbpModule
    {

    }
}
```

> After dependening from ABP SignalR module, your current module now able to detect classes that derived
from `Hub` class and register this classes

8. Add folder `SignalrHubs`

9. Add `ChatHub`. It will look like this:
```
public class ChatHub : AbpHub
{
    public async Task SendMessage(string userName, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", userName, message);
    }
}
```

> ABP will find this class and map it to http endpoint by itself. ABP map hubs in this pattern: `/signalr-hubs/(hub class name without Chat suffix)`. In my case route will be:
`/signalr-hubs/chat`

10. In blazor project create page with this razor syntax. Code: 
```
@page "/"
@using Microsoft.AspNetCore.SignalR.Client
@inherits BlazorAbpSignalrComponentBase
@implements IAsyncDisposable

<PageTitle>Index</PageTitle>

<div class="form-group">
    <label>
        User:
        <input @bind="userInput" />
    </label>
</div>
<div class="form-group">
    <label>
        Message:
        <input @bind="messageInput" size="50" />
    </label>
</div>
<button @onclick="Send" disabled="@(!IsConnected)">Send</button>

<hr>

<ul id="messagesList">
    @foreach (var message in messages)
    {
        <li>@message</li>
    }
</ul>

@code {
    private HubConnection? hubConnection;
    private List<string> messages = new List<string>();
    private string? userInput;
    private string? messageInput;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:44393/signalr-hubs/chat")
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (userName, message) =>
        {
            var encodedMsg = $"{userName}: {message}";
            messages.Add(encodedMsg);
            StateHasChanged();
        });

        await hubConnection.StartAsync();
    }

    private async Task Send()
    {
        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("SendMessage", userInput, messageInput);
        }
    }

    public bool IsConnected =>
        hubConnection?.State == HubConnectionState.Connected;

    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
```

> In your project you will already have page with this URL `/` (`Index.razor` file) you can open this file
and change the page directive to something else

***IMPORTANT***

When building hub connection don't forget to change port to yours backend port. In my case this is `44393`

```
hubConnection = new HubConnectionBuilder()
    .WithUrl("https://localhost:44393/signalr-hubs/chat")
    .Build();
```
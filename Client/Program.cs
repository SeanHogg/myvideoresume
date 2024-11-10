using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using MyVideoResume.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "MyVideoResumeTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MyVideoResume.Client.DataContextService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddHttpClient("MyVideoResume.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyVideoResume.Server"));
builder.Services.AddScoped<MyVideoResume.Client.SecurityService>();
builder.Services.AddScoped<AuthenticationStateProvider, MyVideoResume.Client.ApplicationAuthenticationStateProvider>();
var host = builder.Build();
await host.RunAsync();
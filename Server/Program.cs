using Radzen;
using MyVideoResume.Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using MyVideoResume.Server.Data;
using Microsoft.AspNetCore.Identity;
using MyVideoResume.Server.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Serilog.Events;
using Serilog;
using IdentityModel;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.ML;
using MyVideoResume.ML.SentimentAnalysis.DataModels;

var builder = WebApplication.CreateBuilder(args);
//Logging
var loggingConnectionString = builder.Configuration.GetConnectionString("Logging");
var newRelicKey = builder.Configuration.GetValue<string>("NewRelic:LoggingKey");
var loggerConfiguration = new LoggerConfiguration()
#if DEBUG
.MinimumLevel.Debug()
#else
.MinimumLevel.Warning()
#endif

.Enrich.FromLogContext()

#if RELEASE
.WriteTo.NewRelicLogs(endpointUrl: "https://log-api.newrelic.com/log/v1", applicationName: "MyVideoResu.ME", licenseKey: newRelicKey)
#else
.WriteTo.Async(c => c.Console())
.WriteTo.Async(c => c.File($"Logs/logs{DateTime.Now.ToEpochTime()}.txt"))
.WriteTo.MSSqlServer(connectionString: loggingConnectionString, sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true })
#endif
;

Log.Logger = loggerConfiguration.CreateLogger();


// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(options => options.MaximumReceiveMessageSize = 10 * 1024 * 1024).AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "MyVideoResumeTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<MyVideoResume.Server.DataContextService>();
builder.Services.AddDbContext<MyVideoResume.Server.Data.DataContextContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderDataContext = new ODataConventionModelBuilder();
    opt.AddRouteComponents("odata/DataContext", oDataBuilderDataContext.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});

// Register the PredictionEnginePool as a service in the IoC container for DI
builder.Services.AddPredictionEnginePool<SampleObservation, SamplePrediction>()
                    .FromFile(builder.Configuration["MLModel:MLModelFilePath"]); 

builder.Services.AddScoped<MyVideoResume.Client.DataContextService>();
builder.Services.AddHttpClient("MyVideoResume.Server").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseCookies = false }).AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<MyVideoResume.Client.SecurityService>();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers().AddOData(o =>
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
    var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.Password)));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.ConfirmPassword)));
    oDataBuilder.EntitySet<ApplicationRole>("ApplicationRoles");
    o.AddRouteComponents("odata/Identity", oDataBuilder.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<AuthenticationStateProvider, MyVideoResume.Client.ApplicationAuthenticationStateProvider>();

builder.Host.UseSerilog();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.MapControllers();
app.UseHeaderPropagation();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(typeof(MyVideoResume.Client._Imports).Assembly);
app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>().Database.Migrate();
app.Run();
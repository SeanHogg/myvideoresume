using Hangfire.Client;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Server;
using Hangfire.States;
using System.Diagnostics.CodeAnalysis;

namespace MyVideoResume.Workers;

public class MyAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var allowedAccess = false;
        var httpContext = context.GetHttpContext();

        // Allow all authenticated users to see the Dashboard (potentially dangerous).
        allowedAccess = httpContext.User.Identity?.IsAuthenticated ?? false && httpContext.User.IsInRole("admin");

        return allowedAccess;
    }
}

public class CustomBackgroundJobFactory : IBackgroundJobFactory
{
    private readonly IBackgroundJobFactory _inner;

    public CustomBackgroundJobFactory([NotNull] IBackgroundJobFactory inner)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    public IStateMachine StateMachine => _inner.StateMachine;

    public BackgroundJob Create(CreateContext context)
    {
        Console.WriteLine($"Create: {context.Job.Type.FullName}.{context.Job.Method.Name} in {context.InitialState?.Name} state");
        return _inner.Create(context);
    }
}

public class CustomBackgroundJobPerformer : IBackgroundJobPerformer
{
    private readonly IBackgroundJobPerformer _inner;

    public CustomBackgroundJobPerformer([NotNull] IBackgroundJobPerformer inner)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    public object Perform(PerformContext context)
    {
        Console.WriteLine($"Perform {context.BackgroundJob.Id} ({context.BackgroundJob.Job.Type.FullName}.{context.BackgroundJob.Job.Method.Name})");
        return _inner.Perform(context);
    }
}

public class CustomBackgroundJobStateChanger : IBackgroundJobStateChanger
{
    private readonly IBackgroundJobStateChanger _inner;

    public CustomBackgroundJobStateChanger([NotNull] IBackgroundJobStateChanger inner)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    public IState ChangeState(StateChangeContext context)
    {
        Console.WriteLine($"ChangeState {context.BackgroundJobId} to {context.NewState}");
        return _inner.ChangeState(context);
    }
}

public class RecurringJobsService : BackgroundService
{
    private readonly IBackgroundJobClient _backgroundJobs;
    private readonly IRecurringJobManager _recurringJobs;
    private readonly ILogger<RecurringJobScheduler> _logger;

    public RecurringJobsService(
        [NotNull] IBackgroundJobClient backgroundJobs,
        [NotNull] IRecurringJobManager recurringJobs,
        [NotNull] ILogger<RecurringJobScheduler> logger)
    {
        _backgroundJobs = backgroundJobs ?? throw new ArgumentNullException(nameof(backgroundJobs));
        _recurringJobs = recurringJobs ?? throw new ArgumentNullException(nameof(recurringJobs));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _recurringJobs.AddOrUpdate("Send", () => Console.WriteLine("Hello, seconds!"), "*/15 * * * * *");
            _recurringJobs.AddOrUpdate("minutely", () => Console.WriteLine("Hello, world!"), Cron.Minutely);
            _recurringJobs.AddOrUpdate("hourly", () => Console.WriteLine("Hello"), "25 15 * * *");
            _recurringJobs.AddOrUpdate("neverfires", () => Console.WriteLine("Can only be triggered"), "0 0 31 2 *");

            _recurringJobs.AddOrUpdate("Hawaiian", () => Console.WriteLine("Hawaiian"), "15 08 * * *", new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time")
            });
            _recurringJobs.AddOrUpdate("UTC", () => Console.WriteLine("UTC"), "15 18 * * *");
            _recurringJobs.AddOrUpdate("Russian", () => Console.WriteLine("Russian"), "15 21 * * *", new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred while creating recurring jobs.");
        }

        return Task.CompletedTask;
    }
}
namespace MyVideoResume.AI;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAIPromptEngine(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services
           .AddSingleton<PromptEngine>()
           .AddControllers()
           .AddApplicationPart(typeof(IServiceCollectionExtensions).Assembly);

        return services;
    }
}

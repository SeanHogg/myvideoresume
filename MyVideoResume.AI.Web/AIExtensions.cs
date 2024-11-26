using Microsoft.Extensions.DependencyInjection;

namespace MyVideoResume.AI;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAIPromptEngine(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services
           .AddSingleton<IPromptEngine, OpenAIPromptEngine>()
           .AddControllers()
           .AddApplicationPart(typeof(IServiceCollectionExtensions).Assembly);

        return services;
    }
}

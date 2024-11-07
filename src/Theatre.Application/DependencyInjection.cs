using Microsoft.Extensions.DependencyInjection;
using Theatre.Application.Services;

namespace Theatre.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(cfg => { cfg.ServiceLifetime = ServiceLifetime.Scoped; });
        services.AddScoped<ISmsService, TwilioSmsService>();        
        return services;
    }
}
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Theatre.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(cfg => { cfg.ServiceLifetime = ServiceLifetime.Scoped; });
        return services;
    }
}
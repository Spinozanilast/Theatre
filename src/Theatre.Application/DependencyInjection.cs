using Microsoft.Extensions.DependencyInjection;

namespace Theatre.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
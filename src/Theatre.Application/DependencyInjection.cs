using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Theatre.CqrsMediator;
using Theatre.CqrsMediator.Commands;

namespace Theatre.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCqrsMediator(Assembly.GetExecutingAssembly());
        return services;
    }
}
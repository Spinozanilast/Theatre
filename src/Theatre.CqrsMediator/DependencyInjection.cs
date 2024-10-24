using System.Collections.ObjectModel;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Extensions.DependencyInjection;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Dispatchers;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator;

public static class DependencyInjection
{
    private static readonly IEnumerable<Type> CqrsHandlers =
    [
        typeof(IQueryHandler<,>),
        typeof(IQueryHandlerWithCancellation<,>),
        typeof(ICommandHandler<>),
        typeof(ICommandHandler<,>),
        typeof(ICommandHandlerWithCancellation<>),
        typeof(ICommandHandlerWithCancellation<,>)
    ];

    private static readonly IEnumerable<Type> CqrsReturnTypes =
    [
        typeof(IReturnType),
        typeof(IReturnType<>)
    ];

    public static IServiceCollection AddCqrsMediator(this IServiceCollection services, Assembly assembly)
    {
        services.RegisterHandlers(assembly);

        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.AddSingleton<ICommandDispatcherWithCancellation, CommandDispatcher>();
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.AddSingleton<IQueryDispatcherWithCancellation, QueryDispatcher>();
        return services;
    }

    private static IServiceCollection RegisterHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly
            .GetTypes()
            .Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IHandler)));

        foreach (var handlerType in handlerTypes)
        {
            services.AddScoped(handlerType.GetGenericInterfaceOfType(CqrsHandlers), handlerType);
        }

        return services;
    }

    private static Type GetGenericInterfaceOfType(this Type type, IEnumerable<Type> existingTypeCollection)
    {
        return type.GetInterfaces().First(i =>
            i.IsGenericType && existingTypeCollection.Any(t => t == i.GetGenericTypeDefinition()));
    }
}
using Microsoft.Extensions.DependencyInjection;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Dispatchers;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher, IQueryDispatcherWithCancellation
{
    public Task<TQueryOutput> Dispatch<TQueryOutput>(IReturnType<TQueryOutput> query,
        CancellationToken cancellationToken)
    {
        var handlerType = typeof(IQueryHandlerWithCancellation<,>)
            .FillGenericInterfaceWithTwoParameters(query.GetType(), typeof(TQueryOutput));
        var handler = (IQueryHandlerWithCancellation<IReturnType<TQueryOutput>, TQueryOutput>)serviceProvider
            .GetRequiredService(handlerType);
        return handler.Handle(query, cancellationToken);
    }

    public Task<TQueryOutput> Dispatch<TQueryOutput>(IReturnType<TQueryOutput> query)
    {
        var handlerType = typeof(IQueryHandler<,>)
            .FillGenericInterfaceWithTwoParameters(query.GetType(), typeof(TQueryOutput));
        var handler =
            (IQueryHandler<IReturnType<TQueryOutput>, TQueryOutput>)serviceProvider.GetRequiredService(handlerType);
        return handler.Handle(query);
    }
}
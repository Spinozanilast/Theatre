using Microsoft.Extensions.DependencyInjection;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Dispatchers;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher, IQueryDispatcherWithCancellation
{
    public Task<TQueryOutput> Dispatch<TQueryOutput>(IReturnType<TQueryOutput> query, CancellationToken cancellation)
    {
        var handler = serviceProvider
            .GetRequiredService<IQueryHandlerWithCancellation<IReturnType<TQueryOutput>, TQueryOutput>>();
        return handler.Handle(query, cancellation);
    }

    public Task<TQueryOutput> Dispatch<TQueryOutput>(IReturnType<TQueryOutput> query)
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<IReturnType<TQueryOutput>, TQueryOutput>>();
        return handler.Handle(query);
    }
}
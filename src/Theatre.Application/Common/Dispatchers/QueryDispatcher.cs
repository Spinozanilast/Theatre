using Microsoft.Extensions.DependencyInjection;

namespace Theatre.Application.Common.Dispatchers;

public class QueryDispatcher(IServiceProvider serviceProvider): IQueryDispatcher
{
    public Task<TQueryOutput> Dispatch<TQuery, TQueryOutput>(TQuery query, CancellationToken cancellation)
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryOutput>>();
        return handler.Handle(query, cancellation);
    }
}
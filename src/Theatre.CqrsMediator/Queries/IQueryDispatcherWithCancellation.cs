
using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Queries;

public interface IQueryDispatcherWithCancellation
{
    Task<TQueryOutput> Dispatch<TQueryOutput>(IReturnType<TQueryOutput> query, CancellationToken cancellation);
}
namespace Theatre.Application.Common;

public interface IQueryDispatcher
{
    Task<TQueryOutput> Dispatch<TQuery, TQueryOutput>(TQuery query, CancellationToken cancellation);
}
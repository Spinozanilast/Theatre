namespace Theatre.CqrsMediator.Queries;

public interface IQueryHandlerWithCancellation<in TQuery, TQueryOutput>
{
    Task<TQueryOutput> Handle(TQuery query, CancellationToken cancellation);
}
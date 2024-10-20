namespace Theatre.Application.Common;

public interface IQueryHandler<in TQuery, TQueryOutput>
{
    Task<TQueryOutput> Handle(TQuery query, CancellationToken cancellation);
}
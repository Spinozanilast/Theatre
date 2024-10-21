using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Queries;

public interface IQueryHandler<in TQuery, TQueryOutput> where TQuery: IReturnType<TQueryOutput>
{
    Task<TQueryOutput> Handle(TQuery query);
}
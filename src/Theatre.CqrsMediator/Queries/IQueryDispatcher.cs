using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Queries;

public interface IQueryDispatcher
{
    Task<TQueryOutput> Dispatch<TQueryOutput>(IReturnType<TQueryOutput> query);
}
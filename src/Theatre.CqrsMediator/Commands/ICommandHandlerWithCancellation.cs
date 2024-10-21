using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Commands;

public interface ICommandHandlerWithCancellation<in TQuery, TQueryOutput> where TQuery : IReturnType<TQueryOutput>
{
    Task<TQueryOutput> Handle(TQuery query, CancellationToken cancellation);
}

public interface ICommandHandlerWithCancellation<in TQuery> where TQuery : IReturnType
{
    Task Handle(TQuery query, CancellationToken cancellation);
}
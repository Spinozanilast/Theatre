using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Commands;

public interface ICommandDispatcherWithCancellation

{
    Task<TCommandOutput> Dispatch<TCommandOutput>(IReturnType<TCommandOutput> command, CancellationToken cancellation);
}
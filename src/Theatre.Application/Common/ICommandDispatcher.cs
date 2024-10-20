namespace Theatre.Application.Common;

public interface ICommandDispatcher
{
    Task<TCommandOutput> Dispatch<TCommand, TCommandOutput>(TCommand command, CancellationToken cancellation);
}
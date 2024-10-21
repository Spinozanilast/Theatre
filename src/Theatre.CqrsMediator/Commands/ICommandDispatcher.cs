using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Commands;

public interface ICommandDispatcher
{
    Task<TCommandOutput> Dispatch<TCommandOutput>(IReturnType<TCommandOutput> command);
}
using Microsoft.Extensions.DependencyInjection;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.CqrsMediator.Dispatchers;

public class CommandDispatcher(IServiceProvider serviceProvider)
    : ICommandDispatcher, ICommandDispatcherWithCancellation
{
    public Task<TCommandOutput> Dispatch<TCommandOutput>(IReturnType<TCommandOutput> command,
        CancellationToken cancellation)
    {
        var handler = serviceProvider
            .GetRequiredService<ICommandHandlerWithCancellation<IReturnType<TCommandOutput>, TCommandOutput>>();
        return handler.Handle(command, cancellation);
    }

    public Task<TCommandOutput> Dispatch<TCommandOutput>(IReturnType<TCommandOutput> command)
    {
        var handler = serviceProvider
            .GetRequiredService<ICommandHandler<IReturnType<TCommandOutput>, TCommandOutput>>();
        return handler.Handle(command);
    }
}
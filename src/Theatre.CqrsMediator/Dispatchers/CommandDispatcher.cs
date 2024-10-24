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
        var handlerType = typeof(ICommandHandlerWithCancellation<,>)
            .FillGenericInterfaceWithTwoParameters(command.GetType(), typeof(TCommandOutput));
        var handler = (ICommandHandlerWithCancellation<IReturnType<TCommandOutput>, TCommandOutput>)serviceProvider
            .GetRequiredService(handlerType);
        return handler.Handle(command, cancellation);
    }

    public async Task Dispatch(IReturnType command, CancellationToken cancellation)
    {
        var handlerType = typeof(ICommandHandlerWithCancellation<>)
            .FillGenericInterfaceWithTwoParameters(command.GetType(), null);
        var handler = (ICommandHandlerWithCancellation<IReturnType>)serviceProvider
            .GetRequiredService(handlerType);
        await handler.Handle(command, cancellation);
    }

    public Task<TCommandOutput> Dispatch<TCommandOutput>(IReturnType<TCommandOutput> command)
    {
        var handlerType = typeof(ICommandHandler<,>)
            .FillGenericInterfaceWithTwoParameters(command.GetType(), typeof(TCommandOutput));
        var handler = (ICommandHandler<IReturnType<TCommandOutput>, TCommandOutput>)serviceProvider
            .GetRequiredService(handlerType);
        return handler.Handle(command);
    }

    public async Task Dispatch(IReturnType command)
    {
        var handlerType = typeof(ICommandHandler<>)
            .FillGenericInterfaceWithTwoParameters(command.GetType(), null);
        var handler = (ICommandHandler<IReturnType>)serviceProvider
            .GetRequiredService(handlerType);
        await handler.Handle(command);
    }
}
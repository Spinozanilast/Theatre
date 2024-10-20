using Microsoft.Extensions.DependencyInjection;

namespace Theatre.Application.Common.Dispatchers;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public Task<TCommandOutput> Dispatch<TCommand, TCommandOutput>(TCommand command,
        CancellationToken cancellation)
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandOutput>>();
        return handler.Handle(command, cancellation);
    }
}
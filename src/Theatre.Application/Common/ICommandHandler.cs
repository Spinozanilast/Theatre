namespace Theatre.Application.Common;

public interface ICommandHandler<in TCommand, TCommandOutput>
{
    Task<TCommandOutput> Handle(TCommand command, CancellationToken cancellation);
}

public interface ICommandHandler<in TCommand>
{
    Task Handle(TCommand command, CancellationToken cancellation);
}
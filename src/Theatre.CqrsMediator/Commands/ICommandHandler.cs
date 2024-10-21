namespace Theatre.CqrsMediator.Commands;

public interface ICommandHandler<in TCommand, TCommandOutput>
{
    Task<TCommandOutput> Handle(TCommand query);
}

public interface ICommandHandler<in TCommandOutput>
{
    Task Handle(TCommandOutput command);
}
using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Events.Commands;

public record DeleteEventCommand(Guid EventId):  ICommand<ErrorOr<Success>>;

public class DeleteEventCommandHandler(IEventsRepository eventsRepository) : ICommandHandler<DeleteEventCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        await eventsRepository.DeleteAsync(command.EventId);

        return Result.Success;
    }
}
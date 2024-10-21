using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Events.Commands;

public record DeleteEventCommand(Guid EventId) : IReturnType<ErrorOr<Success>>;

public class DeleteEventCommandHandler(IEventsRepository eventsRepository)
    : ICommandHandlerWithCancellation<DeleteEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        await eventsRepository.DeleteAsync(command.EventId);

        return Result.Success;
    }
}
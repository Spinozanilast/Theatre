using ErrorOr;
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Events.Commands;

public record DeleteEventCommand(Guid EventId);

public class DeleteEventCommandHandler(IEventsRepository eventsRepository)
    : ICommandHandler<DeleteEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        await eventsRepository.DeleteAsync(command.EventId);

        return Result.Success;
    }
}
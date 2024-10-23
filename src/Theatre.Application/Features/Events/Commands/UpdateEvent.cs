using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities.Enumerations;
using Theatre.Domain.Entities.Special;

namespace Theatre.Application.Features.Events.Commands;

public record UpdateEventCommand(
    Guid EventId,
    string Name,
    EventType EventType,
    DateTime DateTime,
    int HallId,
    string Description,
    EventCast EventCast,
    decimal Price,
    bool EventState
) : IReturnType<ErrorOr<Success>>;

public class UpdateEventCommandHandler(
    IEventsRepository eventsRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandlerWithCancellation<UpdateEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
    {
        var eventToUpdate = await eventsRepository.GetByIdAsync(command.EventId);
        if (eventToUpdate is null)
        {
            return Error.NotFound("Event not found");
        }

        eventToUpdate.Update(command.Name, command.Description, command.DateTime, command.HallId, command.Price,
            command.EventType, command.EventCast);
        await eventsRepository.UpdateAsync(eventToUpdate);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}
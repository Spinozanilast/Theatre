using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enums;
using Theatre.Domain.Entities.Special;

namespace Theatre.Application.Features.Events.Commands;

public record CreateEventCommand(
    string Name,
    string Description,
    DateTime Date,
    short HallId,
    decimal Price,
    EventType EventType,
    EventCast EventCast)
    : IRequest<ErrorOr<Success>>;

public class CreateEventCommandHandler(
    IEventsRepository eventsRepository,
    IHallsRepository hallsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        var hall = await hallsRepository.GetByIdAsync(command.HallId);

        if (hall is null)
        {
            return Error.NotFound(description: "Hall not found");
        }

        var eventEntity = new Event(
            Guid.NewGuid(),
            command.Name,
            command.Date,
            command.HallId,
            command.Price,
            true,
            command.EventType,
            command.EventCast,
            command.Description);

        await eventsRepository.CreateAsync(eventEntity);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}
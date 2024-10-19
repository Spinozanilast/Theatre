using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Application.Events.Commands;

public record CreateEventCommand(
    string Name,
    string Description,
    DateTime Date,
    short HallId,
    decimal Price,
    EventType EventType,
    IEnumerable<string>? Directors,
    IEnumerable<string>? ScreenWriters,
    IEnumerable<string>? Actors)
    : IRequest<ErrorOr<Success>>;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ErrorOr<Success>>
{
    private readonly IEventsRepository _eventsRepository;
    private readonly IHallsRepository _hallsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(
        IEventsRepository eventsRepository,
        IHallsRepository hallsRepository,
        IUnitOfWork unitOfWork)
    {
        _eventsRepository = eventsRepository;
        _hallsRepository = hallsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Success>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        var hall = await _hallsRepository.GetByIdAsync(command.HallId);

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
            command.Directors,
            command.ScreenWriters,
            command.Actors);

        await _eventsRepository.CreateAsync(eventEntity);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}
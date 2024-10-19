using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Application.Events.Commands;

public record UpdateEventCommand(Event UpdatedEvent)
    : IRequest<ErrorOr<Success>>;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ErrorOr<Success>>
{
    private readonly IEventsRepository _eventsRepository;
    private readonly IHallsRepository _hallsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventCommandHandler(
        IEventsRepository eventsRepository,
        IHallsRepository hallsRepository,
        IUnitOfWork unitOfWork)
    {
        _eventsRepository = eventsRepository;
        _hallsRepository = hallsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Success>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _eventsRepository.GetByIdAsync(command.UpdatedEvent.Id);
        if (eventToUpdate is null)
        {
            return Error.NotFound("Event not found");
        }
        
        await _eventsRepository.UpdateAsync(command.UpdatedEvent);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}
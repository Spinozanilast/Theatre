using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;
using Theatre.Domain.Entities.Enums;

namespace Theatre.Application.Events.Commands;

public record UpdateEventCommand(Event UpdatedEvent)
    : IRequest<ErrorOr<Success>>;

public class UpdateEventCommandHandler(
    IEventsRepository eventsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
    {
        var eventToUpdate = await eventsRepository.GetByIdAsync(command.UpdatedEvent.Id);
        if (eventToUpdate is null)
        {
            return Error.NotFound("Event not found");
        }
        
        await eventsRepository.UpdateAsync(command.UpdatedEvent);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Success;
    }
}
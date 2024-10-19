using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Events.Commands;

public record DeleteEventCommand(Guid EventId) : IRequest<ErrorOr<Success>>;

public class DeleteEventCommandHandler(IEventsRepository eventsRepository)
    : IRequestHandler<DeleteEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        await eventsRepository.DeleteAsync(command.EventId);

        return Result.Success;
    }
}
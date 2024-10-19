using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Events.Commands;

public record DeleteEventCommand(Guid EventId) : IRequest<ErrorOr<Success>>;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ErrorOr<Success>>
{
    private readonly IEventsRepository _eventsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEventCommandHandler(
        IEventsRepository eventsRepository,
        IUnitOfWork unitOfWork)
    {
        _eventsRepository = eventsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Success>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        await _eventsRepository.DeleteAsync(command.EventId);

        return Result.Success;
    }
}
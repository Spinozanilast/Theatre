using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Seats.Commands;

public record DeleteSeatCommand(int Id)
    : IRequest<ErrorOr<Success>>;

public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, ErrorOr<Success>>
{
    private readonly ISeatsRepository _seatsRepository;

    public DeleteSeatCommandHandler(ISeatsRepository seatsRepository)
    {
        _seatsRepository = seatsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        await _seatsRepository.DeleteAsync(request.Id);
        return Result.Success;
    }
}
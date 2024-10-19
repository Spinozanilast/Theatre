using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Seats.Commands;

public record DeleteSeatCommand(int Id)
    : IRequest<ErrorOr<Success>>;

public class DeleteSeatCommandHandler(ISeatsRepository seatsRepository)
    : IRequestHandler<DeleteSeatCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        await seatsRepository.DeleteAsync(request.Id);
        return Result.Success;
    }
}
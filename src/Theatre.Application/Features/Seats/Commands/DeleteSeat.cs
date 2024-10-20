using ErrorOr;

using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Seats.Commands;

public record DeleteSeatCommand(int Id);
public class DeleteSeatCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<DeleteSeatCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        await seatsRepository.DeleteAsync(request.Id);
        return Result.Success;
    }
}
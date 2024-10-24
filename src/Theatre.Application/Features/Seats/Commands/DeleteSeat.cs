using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Seats.Commands;

public record DeleteSeatCommand(int Id): ICommand<ErrorOr<Success>>;

public class DeleteSeatCommandHandler(ISeatsRepository seatsRepository): ICommandHandler<DeleteSeatCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(DeleteSeatCommand request, CancellationToken cn = default)
    {
        await seatsRepository.DeleteAsync(request.Id);
        return Result.Success;
    }
}
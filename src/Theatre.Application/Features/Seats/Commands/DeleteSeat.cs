using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Seats.Commands;

public record DeleteSeatCommand(int Id) : IReturnType<ErrorOr<Success>>;

public class DeleteSeatCommandHandler(ISeatsRepository seatsRepository)
    : ICommandHandler<DeleteSeatCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteSeatCommand request)
    {
        await seatsRepository.DeleteAsync(request.Id);
        return Result.Success;
    }
}
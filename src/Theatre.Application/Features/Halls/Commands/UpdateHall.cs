using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Halls.Commands;

public record UpdateHallCommand(int Id, int SeatsNum, string HallName) : IReturnType<ErrorOr<Success>>;

public class UpdateHallCommandHandler(IHallsRepository hallsRepository)
    : ICommandHandler<UpdateHallCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateHallCommand request)
    {
        var hall = await hallsRepository.GetByIdAsync(request.Id);
        if (hall is null)
        {
            return Error.NotFound("Hall not found");
        }

        hall.Update(request.SeatsNum, request.HallName);
        await hallsRepository.UpdateAsync(hall);
        return Result.Success;
    }
}
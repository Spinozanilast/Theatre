using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Halls.Commands;

public record UpdateHallCommand(int Id, int SeatsNum, string HallName): ICommand<ErrorOr<Success>>;

public class UpdateHallCommandHandler(IHallsRepository hallsRepository)
    : ICommandHandler<UpdateHallCommand, ErrorOr<Success>>
{
    public async ValueTask<ErrorOr<Success>> Handle(UpdateHallCommand request, CancellationToken cn = default)
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
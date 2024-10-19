using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Halls.Commands;

public record UpdateHallCommand(short Id, int SeatsNum, string HallName) : IRequest<ErrorOr<Success>>;

public class UpdateHallCommandHandler(IHallsRepository hallsRepository)
    : IRequestHandler<UpdateHallCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateHallCommand request, CancellationToken cancellationToken)
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
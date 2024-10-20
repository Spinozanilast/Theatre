using ErrorOr;

using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Commands;

public record CreateHallCommand(int SeatsNum, string HallName);

public class CreateHallCommandHandler(IHallsRepository hallsRepository)
    : ICommandHandler<CreateHallCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = new Hall(request.SeatsNum, request.HallName);
        await hallsRepository.CreateAsync(hall);
        return Result.Success;
    }
}
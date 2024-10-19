using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Halls.Commands;

public record CreateHallCommand(int SeatsNum, string HallName) : IRequest<ErrorOr<Success>>;

public class CreateHallCommandHandler(IHallsRepository hallsRepository)
    : IRequestHandler<CreateHallCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = new Hall(request.SeatsNum, request.HallName);
        await hallsRepository.CreateAsync(hall);
        return Result.Success;
    }
}
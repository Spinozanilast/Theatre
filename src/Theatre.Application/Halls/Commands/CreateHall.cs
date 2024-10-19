using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Halls.Commands;

public record CreateHallCommand(int SeatsNum, string HallName) : IRequest<ErrorOr<Success>>;

public class CreateHallCommandHandler : IRequestHandler<CreateHallCommand, ErrorOr<Success>>
{
    private readonly IHallsRepository _hallsRepository;

    public CreateHallCommandHandler(IHallsRepository hallsRepository)
    {
        _hallsRepository = hallsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = new Hall(request.SeatsNum, request.HallName);
        await _hallsRepository.CreateAsync(hall);
        return Result.Success;
    }
}
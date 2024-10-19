using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Halls.Commands;

public record UpdateHallCommand(short Id, int SeatsNum, string HallName) : IRequest<ErrorOr<Success>>;

public class UpdateHallCommandHandler : IRequestHandler<UpdateHallCommand, ErrorOr<Success>>
{
    private readonly IHallsRepository _hallsRepository;

    public UpdateHallCommandHandler(IHallsRepository hallsRepository)
    {
        _hallsRepository = hallsRepository;
    }

    public async Task<ErrorOr<Success>> Handle(UpdateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _hallsRepository.GetByIdAsync(request.Id);
        if (hall is null)
        {
            return Error.NotFound("Hall not found");
        }

        hall.Update(request.SeatsNum, request.HallName);
        await _hallsRepository.UpdateAsync(hall);
        return Result.Success;
    }
}
using Mediator;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Halls.Commands;

public record DeleteHallCommand(int HallId): ICommand;

public class DeleteHall(IHallsRepository hallsRepository): ICommandHandler<DeleteHallCommand>
{
    public async ValueTask<Unit> Handle(DeleteHallCommand request, CancellationToken cn = default)
    {
        await hallsRepository.DeleteAsync(request.HallId);
        return Unit.Value;
    }
}
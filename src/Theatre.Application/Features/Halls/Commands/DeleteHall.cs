
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Halls.Commands;

public record DeleteHallCommand(short HallId);

public class DeleteHall(IHallsRepository hallsRepository) : ICommandHandler<DeleteHallCommand>
{
    public async Task Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        await hallsRepository.DeleteAsync(request.HallId);
    }
}
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;

namespace Theatre.Application.Features.Halls.Commands;

public record DeleteHallCommand(int HallId) : IReturnType;

public class DeleteHall(IHallsRepository hallsRepository) : ICommandHandler<DeleteHallCommand>
{
    public async Task Handle(DeleteHallCommand request)
    {
        await hallsRepository.DeleteAsync(request.HallId);
    }
}
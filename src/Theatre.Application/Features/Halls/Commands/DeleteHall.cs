using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Features.Halls.Commands;

public record DeleteHallCommand(short HallId) : IRequest;

public class DeleteHall(IHallsRepository hallsRepository) : IRequestHandler<DeleteHallCommand>
{
    public async Task Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        await hallsRepository.DeleteAsync(request.HallId);
    }
}
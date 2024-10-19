using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;

namespace Theatre.Application.Halls.Commands;

public record DeleteHallCommand(short HallId) : IRequest;

public class DeleteHall : IRequestHandler<DeleteHallCommand>
{
    private readonly IHallsRepository _hallsRepository;

    public DeleteHall(IHallsRepository hallsRepository)
    {
        _hallsRepository = hallsRepository;
    }

    public async Task Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        await _hallsRepository.DeleteAsync(request.HallId);
    }
}
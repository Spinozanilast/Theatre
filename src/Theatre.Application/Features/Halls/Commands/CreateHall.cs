using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Commands;

public record CreateHallCommand(int SeatsNum, string HallName, int SchemeGridRowsCount, int SchemeGridColumnsCount)
    : ICommand<ErrorOr<Hall>>;

public class CreateHallCommandHandler(IHallsRepository hallsRepository)
    : ICommandHandler<CreateHallCommand, ErrorOr<Hall>>
{
    public async ValueTask<ErrorOr<Hall>> Handle(CreateHallCommand request, CancellationToken ct = default)
    {
        var hall = new Hall(request.SeatsNum, request.HallName, request.SchemeGridRowsCount,
            request.SchemeGridColumnsCount);
        await hallsRepository.CreateAsync(hall);
        return hall;
    }
}
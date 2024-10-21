using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetHallByIdQuery(short Id): IReturnType<ErrorOr<Hall>>;

public class GetHallByIdQueryHandler(IHallsRepository hallsRepository)
    : ICommandHandler<GetHallByIdQuery, ErrorOr<Hall>>
{
    public async Task<ErrorOr<Hall>> Handle(GetHallByIdQuery request)
    {
        var hall = await hallsRepository.GetByIdAsync(request.Id);
        return hall is not null
            ? hall
            : Error.NotFound($"Hall with id {request.Id} not found");
    }
}
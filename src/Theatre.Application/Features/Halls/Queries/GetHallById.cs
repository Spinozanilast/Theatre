using ErrorOr;
using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetHallByIdQuery(int Id): IQuery<ErrorOr<Hall>>;

public class GetHallByIdQueryHandler(IHallsRepository hallsRepository): IQueryHandler<GetHallByIdQuery, ErrorOr<Hall>>
{
    public async ValueTask<ErrorOr<Hall>> Handle(GetHallByIdQuery request, CancellationToken cn = default)
    {
        var hall = await hallsRepository.GetByIdAsync(request.Id);
        return hall is not null
            ? hall
            : Error.NotFound($"Hall with id {request.Id} not found");
    }
}
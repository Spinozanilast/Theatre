using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetHallByIdQuery(short Id) : IRequest<ErrorOr<Hall>>;

public class GetHallByIdQueryHandler(IHallsRepository hallsRepository)
    : IRequestHandler<GetHallByIdQuery, ErrorOr<Hall>>
{
    public async Task<ErrorOr<Hall>> Handle(GetHallByIdQuery request, CancellationToken cancellationToken)
    {
        var hall = await hallsRepository.GetByIdAsync(request.Id);
        return hall is not null
            ? hall
            : Error.NotFound($"Hall with id {request.Id} not found");
    }
}
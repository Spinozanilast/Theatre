using ErrorOr;
using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Halls.Queries;

public record GetHallByIdQuery(short Id) : IRequest<ErrorOr<Hall>>;

public class GetHallByIdQueryHandler : IRequestHandler<GetHallByIdQuery, ErrorOr<Hall>>
{
    private readonly IHallsRepository _hallsRepository;

    public GetHallByIdQueryHandler(IHallsRepository hallsRepository)
    {
        _hallsRepository = hallsRepository;
    }

    public async Task<ErrorOr<Hall>> Handle(GetHallByIdQuery request, CancellationToken cancellationToken)
    {
        var hall = await _hallsRepository.GetByIdAsync(request.Id);
        return hall is not null
            ? hall
            : Error.NotFound($"Hall with id {request.Id} not found");
    }
}
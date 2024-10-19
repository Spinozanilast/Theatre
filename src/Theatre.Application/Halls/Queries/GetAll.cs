using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Halls.Queries;

public record GetAllHallsQuery() : IRequest<IList<Hall>>;

public class GetAllHallsQueryHandler : IRequestHandler<GetAllHallsQuery, IList<Hall>>
{
    private readonly IHallsRepository _hallsRepository;

    public GetAllHallsQueryHandler(IHallsRepository hallsRepository)
    {
        _hallsRepository = hallsRepository;
    }

    public async Task<IList<Hall>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
    {
        return await _hallsRepository.GetAllAsync();
    }
}
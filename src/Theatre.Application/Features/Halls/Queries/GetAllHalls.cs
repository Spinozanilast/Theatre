using Mediator;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetAllHallsQuery(): IQuery<List<Hall>>;

public class GetAllHallsQueryHandler(IHallsRepository hallsRepository) : IQueryHandler<GetAllHallsQuery, List<Hall>>
{
    public async ValueTask<List<Hall>> Handle(GetAllHallsQuery request, CancellationToken cn = default)
    {
        return await hallsRepository.GetAllAsync();
    }
}
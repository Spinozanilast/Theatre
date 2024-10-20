
using Theatre.Application.Common;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetAllHallsQuery();

public class GetAllHallsQueryHandler(IHallsRepository hallsRepository) : ICommandHandler<GetAllHallsQuery, IList<Hall>>
{
    public async Task<IList<Hall>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
    {
        return await hallsRepository.GetAllAsync();
    }
}
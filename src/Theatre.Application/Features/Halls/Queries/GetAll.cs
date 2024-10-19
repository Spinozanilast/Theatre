using MediatR;
using Theatre.Application.Common.Interfaces;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetAllHallsQuery() : IRequest<IList<Hall>>;

public class GetAllHallsQueryHandler(IHallsRepository hallsRepository) : IRequestHandler<GetAllHallsQuery, IList<Hall>>
{
    public async Task<IList<Hall>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
    {
        return await hallsRepository.GetAllAsync();
    }
}
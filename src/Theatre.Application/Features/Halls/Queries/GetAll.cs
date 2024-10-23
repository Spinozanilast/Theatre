using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Queries;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Halls.Queries;

public record GetAllHallsQuery(): IReturnType<IList<Hall>>;

public class GetAllHallsQueryHandler(IHallsRepository hallsRepository) : IQueryHandler<GetAllHallsQuery, IList<Hall>>
{
    public async Task<IList<Hall>> Handle(GetAllHallsQuery request)
    {
        return await hallsRepository.GetAllAsync();
    }
}
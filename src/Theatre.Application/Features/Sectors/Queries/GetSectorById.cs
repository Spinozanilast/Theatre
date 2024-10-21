﻿using ErrorOr;
using Theatre.Application.Common.Interfaces;
using Theatre.CqrsMediator.Commands;
using Theatre.CqrsMediator.Special;
using Theatre.Domain.Entities;

namespace Theatre.Application.Features.Sectors.Queries;

public record GetSectorByIdQuery(short SectorId): IReturnType<ErrorOr<Sector>>;

public class GetSectorByIdQueryHandler(ISectorsRepository sectorsRepository)
    : ICommandHandler<GetSectorByIdQuery, ErrorOr<Sector>>
{
    public async Task<ErrorOr<Sector>> Handle(GetSectorByIdQuery request)
    {
        var sector = await sectorsRepository.GetByIdAsync(request.SectorId);
        if (sector is null)
        {
            return Error.NotFound($"Sector with id {request.SectorId} not found");
        }

        return sector;
    }
}
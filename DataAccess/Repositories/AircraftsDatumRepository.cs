using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class AircraftsDatumRepository(DbContext context) : IAircraftsDatumRepository
{
    private readonly DbContext _context = context;

    public async Task<List<AircraftsDatum>> Get()
    {
        var aircraftsDatumEntities = await _context.AircraftsData
            .AsNoTracking()
            .ToListAsync();
        var aircraftsDatum = aircraftsDatumEntities
            .Select(b => AircraftsDatum.CreateAircrafts(b.AircraftCode, b.Model, b.Range).aircraftsDatum)
            .ToList();
        return aircraftsDatum;
    }

    public async Task<string?> Create(AircraftsDatum aircraftsDatum)
    {
        var aircraftsDatumEntity = new AircraftsDatumEntity
        {
            AircraftCode = aircraftsDatum.AircraftCode,
            Model = aircraftsDatum.Model,
            Range = aircraftsDatum.Range,
        };
        await _context.AircraftsData.AddAsync(aircraftsDatumEntity);
        await _context.SaveChangesAsync();
        return aircraftsDatumEntity.AircraftCode;
    }

    public async Task<string> Update(string aircraftCode1 ,string aircraftCode, string model, int range)
    {
        await _context.AircraftsData
            .Where(x => x.AircraftCode == aircraftCode1)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.AircraftCode, x=> aircraftCode)
                .SetProperty(x => x.Model, x => model)
                .SetProperty(x => x.Range, x=> range));
        
        return aircraftCode;
    }

    public async Task<string> Delete(string aircraftCode)
    {
        await _context.AircraftsData
            .Where(x => x.AircraftCode == aircraftCode)
            .ExecuteDeleteAsync();
        return aircraftCode;
    }
}
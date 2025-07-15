using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class AircraftsRepository(DbContext context) : IAircraftsRepository
{
    private readonly DbContext _context = context;

    public async Task<List<Aircraft>> Get()
    {
        var aircraftEntities = await _context.Aircrafts
            .AsNoTracking()
            .ToListAsync();
        var aircrafts = aircraftEntities
            .Select(b => Aircraft.CreateAircraft(b.AircraftCode, b.Model, b.Range).aircraft)
            .ToList();
        return aircrafts;
    }

    public async Task<string?> Create(Aircraft aircraft)
    {
        var aircraftEntity = new AircraftEntity
        {
            AircraftCode = aircraft.AircraftCode,
            Model = aircraft.Model,
            Range = aircraft.Range,
        };
        await _context.Aircrafts.AddAsync(aircraftEntity);
        await _context.SaveChangesAsync();
        return aircraftEntity.AircraftCode;
    }

    public async Task<string> Update(string aircraftCode, string model, int range)
    {
        await _context.Aircrafts
            .Where(x => x.AircraftCode == aircraftCode)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.AircraftCode, x=> aircraftCode)
                .SetProperty(x => x.Model, x => model)
                .SetProperty(x => x.Range, x=> range));
        
        return aircraftCode;
    }

    public async Task<string> Delete(string aircraftCode)
    {
        await _context.Aircrafts
            .Where(x => x.AircraftCode == aircraftCode)
            .ExecuteDeleteAsync();
        return aircraftCode;
    }
}
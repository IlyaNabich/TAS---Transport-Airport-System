using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace DataAccess.Repositories;

public class AirportsDatumRepository(DbContext context) : IAirportsDatumRepository
{
    private readonly DbContext _context = context;
    
    
    public async Task<List<AirportsDatum>> Get()
    {
        var airportsDatumEntities = await _context.AirportsData
            .AsNoTracking()
            .ToListAsync();
        var airportsDatum = airportsDatumEntities
            .Select(x => AirportsDatum.CreateAirports(x.AirportCode, x.AirportName, x.City, x.Coordinates, x.Timezone).airportsDatum)
            .ToList();
        
        return airportsDatum;
    }

    public async Task<string?> Create(AirportsDatum airportsDatum)
    {
        var airportsDatumEntity = new AirportsDatumEntity
        {
            AirportCode = airportsDatum.AirportCode,
            AirportName = airportsDatum.AirportName,
            City = airportsDatum.City,
            Coordinates = airportsDatum.Coordinates,
            Timezone = airportsDatum.Timezone
        };
        await _context.AirportsData.AddAsync(airportsDatumEntity);
        await _context.SaveChangesAsync();
        
        return airportsDatum.AirportCode;
    }

    public async Task<string?> Update(string airportCode, string airportCode1, string airportName, string city, NpgsqlPoint coordinates, string timezone)
    {
        await _context.AirportsData
            .Where(x => x.AirportCode == airportCode1)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.AirportName, airportName)
                .SetProperty(y => y.AirportCode, airportCode)
                .SetProperty(i => i.City, city)
                .SetProperty(n => n.Coordinates, coordinates)
                .SetProperty(a => a.Timezone, timezone));
        
        return airportCode;
    }

    public async Task<string?> Delete(string airportCode)
    {
        await _context.AirportsData
            .Where(x => x.AirportCode == airportCode)
            .ExecuteDeleteAsync();
        
        return airportCode;
    }
}
using Core.Abstractions;
using Core.Interfaces;
using Core.Models;
using NpgsqlTypes;

namespace ClassLibrary1.Services;

public class AirportsDatumService (IAirportsDatumRepository airportsDatumRepository) : IAirportsDatumService
{
    private readonly IAirportsDatumRepository _airportsDatumRepository = airportsDatumRepository;


    public async Task<List<AirportsDatum>> GetAllAirports()
    {
        return await _airportsDatumRepository.Get();
    }

    public async Task<string?> CreateAirports(AirportsDatum airportsDatum)
    {
        return await _airportsDatumRepository.Create(airportsDatum);
    }

    public async Task<string?> UpdateAirports(string airportCode1, string airportCode, string aiportName, string city, NpgsqlPoint coordinates, string timezone)
    {
        return await _airportsDatumRepository.Update(airportCode1, airportCode, aiportName, city, coordinates, timezone);
    }

    public async Task<string?> DeleteAirports(string airportCode)
    {
        return await _airportsDatumRepository.Delete(airportCode);
    }
}
using Core.Models;
using NpgsqlTypes;

namespace Core.Interfaces;

public interface IAirportsDatumService
{
    Task<List<AirportsDatum>> GetAllAirports();
    
    Task<string?> CreateAirports(AirportsDatum airportsDatum);
    
    Task<string?> UpdateAirports(string airportCode1,string airportCode, string aiportName, string city, NpgsqlPoint coordinates, string timezone );
    
    Task<string?> DeleteAirports(string airportCode);
    
}
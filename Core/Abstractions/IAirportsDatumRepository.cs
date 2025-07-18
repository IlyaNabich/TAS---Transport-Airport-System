using Core.Models;
using NpgsqlTypes;

namespace Core.Abstractions;

public interface IAirportsDatumRepository
{
    public Task<List<AirportsDatum>> Get();
    
    public Task<string?> Create(AirportsDatum airportsDatum);
    
    public Task<string?> Update(string airportCode,string airportCode1, string airportName, string city, NpgsqlPoint point, string timezone);
    
    public Task<string?> Delete(string airportCode);
}
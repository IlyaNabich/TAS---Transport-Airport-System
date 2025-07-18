using Core.Models;

namespace Core.Abstractions;

public interface IAircraftsDatumRepository
{
    public Task<List<AircraftsDatum>> Get();

    public Task<string?> Create(AircraftsDatum aircraftsDatum);
    
    public Task<string> Update(string aircraftCode1, string aircraftCode, string model, int range);
    
    public Task<string> Delete(string aircraftCode);
}
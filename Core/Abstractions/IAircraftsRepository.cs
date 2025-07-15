using Core.Models;

namespace Core.Abstractions;

public interface IAircraftsRepository
{
    public Task<List<Aircraft>> Get();

    public Task<string?> Create(Aircraft aircraft);
    
    public Task<string> Update(string aircraftCode, string model, int range);
    
    public Task<string> Delete(string aircraftCode);
}
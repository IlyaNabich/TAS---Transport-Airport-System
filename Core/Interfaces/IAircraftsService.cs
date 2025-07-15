using Core.Models;

namespace ClassLibrary1.Services;

public interface IAircraftsService
{
    Task<List<Aircraft>> GetAllAircrafts();
    Task<string?> CreateAircrafts(Aircraft aircraft);
    Task<string> UpdateAircrafts(string aircraftCode, string model, int range);
    Task<string> DeleteAircrafts(string aircraftCode);
}
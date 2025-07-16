using Core.Models;

namespace Core.Interfaces;

public interface IAircraftsDatumService
{
    Task<List<AircraftsDatum>> GetAllAircrafts();
    Task<string?> CreateAircrafts(AircraftsDatum aircraftsDatum);
    Task<string> UpdateAircrafts(string aircraftCode, string model, int range);
    Task<string> DeleteAircrafts(string aircraftCode);
}
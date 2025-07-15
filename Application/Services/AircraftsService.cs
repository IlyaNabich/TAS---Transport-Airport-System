using Core.Abstractions;
using Core.Models;

namespace ClassLibrary1.Services;

public class AircraftsService(IAircraftsRepository aircraftsRepository) : IAircraftsService
{
    private readonly IAircraftsRepository _aircraftsRepository = aircraftsRepository;

    public async Task<List<Aircraft>> GetAllAircrafts()
    {
        return await _aircraftsRepository.Get();
    }

    public async Task<string?> CreateAircrafts(Aircraft aircraft)
    {
        return await _aircraftsRepository.Create(aircraft);
    }

    public async Task<string> UpdateAircrafts(string aircraftCode, string model, int range)
    {
        return await _aircraftsRepository.Update(aircraftCode, model, range);
    }

    public async Task<string> DeleteAircrafts(string aircraftCode)
    {
        return await _aircraftsRepository.Delete(aircraftCode);
    }
}
using Core.Abstractions;
using Core.Interfaces;
using Core.Models;

namespace ClassLibrary1.Services;

public class AircraftsDatumService(IAircraftsDatumRepository aircraftsDatumRepository) : IAircraftsDatumService
{
    private readonly IAircraftsDatumRepository _aircraftsDatumRepository = aircraftsDatumRepository;

    public async Task<List<AircraftsDatum>> GetAllAircrafts()
    {
        return await _aircraftsDatumRepository.Get();
    }

    public async Task<string?> CreateAircrafts(AircraftsDatum aircraftsDatum)
    {
        return await _aircraftsDatumRepository.Create(aircraftsDatum);
    }

    public async Task<string> UpdateAircrafts(string aircraftCode, string model, int range)
    {
        return await _aircraftsDatumRepository.Update(aircraftCode, model, range);
    }

    public async Task<string> DeleteAircrafts(string aircraftCode)
    {
        return await _aircraftsDatumRepository.Delete(aircraftCode);
    }
}
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Airports;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class AirportsDatumController(IAirportsDatumService airportsDatumService): ControllerBase
{
    private readonly IAirportsDatumService _airportsDatumService = airportsDatumService;
    
    [HttpGet]
    public async Task<ActionResult<AirportsDatum>> GetAirports()
    {
        var airport = await _airportsDatumService.GetAllAirports();
        
        return Ok(airport);
    }

    [HttpPost]
    public async Task<ActionResult<AirportsDatum>> CreateAirport([FromBody] AirportsRequest request)
    {
        var (airport, error) = AirportsDatum.CreateAirports(
            request.AirportCode,
            request.AirportName,
            request.City,
            request.Coordinates,
            request.Timezone
        );

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        
        var airports = await _airportsDatumService.CreateAirports(airport);
        
        return Ok(airports);
    }

    [HttpPut]
    public async Task<ActionResult<AirportsDatum>> UpdateAirport([FromBody] AirportsRequest request, string airportCode1)
    {
        await _airportsDatumService.UpdateAirports(airportCode1, request.AirportCode, request.AirportName, request.City, request.Coordinates, request.Timezone);
        
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult<AirportsDatum>> DeleteAirport(string airportCode)
    {
        await _airportsDatumService.DeleteAirports(airportCode);
        
        return Ok();
    }
}
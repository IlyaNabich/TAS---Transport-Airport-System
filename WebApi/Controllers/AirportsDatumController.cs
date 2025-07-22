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
    public async Task<ActionResult<AirportsResponse>> GetAirports()
    {
        var airport = await _airportsDatumService.GetAllAirports();
        
        var response = airport.Select(x => new AirportsResponse(x.AirportCode, x.AirportName, x.City, x.Coordinates, x.Timezone));
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<AirportsRequest>> CreateAirport([FromBody] AirportsRequest request)
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
    public async Task<ActionResult> UpdateAirport([FromBody] AirportsRequest request, string airportCode1)
    {
        var airports = await _airportsDatumService.UpdateAirports(airportCode1, request.AirportCode, request.AirportName, request.City, request.Coordinates, request.Timezone);
        
        return Ok(airports);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAirport(string airportCode)
    {
        var airports = await _airportsDatumService.DeleteAirports(airportCode);
        
        return Ok(airports);
    }
}
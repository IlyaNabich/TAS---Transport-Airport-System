using ClassLibrary1.Services;
using Core.Interfaces;
using Core.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AircraftsDatumController(IAircraftsDatumService aircraftsDatumService) : ControllerBase
{ 
    private readonly IAircraftsDatumService _aircraftsDatumService = aircraftsDatumService;

    [HttpGet]
    public async Task <ActionResult<List<AircraftsResponse>>> GetAircrafts()
    {
        var aircraft = await _aircraftsDatumService.GetAllAircrafts();
        
        var response = aircraft.Select(x => new AircraftsResponse(x.AircraftCode, x.Model, x.Range));
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<List<AircraftsRequest>>> AddAircraft([FromBody] AircraftsRequest request)
    {
        var (aircraft, error) = AircraftsDatum.CreateAircrafts(
            request.AircraftCode, 
            request.Model, 
            request.Range);
        
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        
        var aircrafts = await _aircraftsDatumService.CreateAircrafts(aircraft);
        
        return Ok(aircrafts);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAircraft([FromBody] AircraftsRequest request)
    {
        var aircrafts = await _aircraftsDatumService.DeleteAircrafts(request.AircraftCode);
        
        return Ok(aircrafts);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAircraft([FromBody] AircraftsRequest request)
    {
        var aircrafts = await _aircraftsDatumService.UpdateAircrafts(request.AircraftCode, request.Model, request.Range);
        
        return Ok(aircrafts);
    }
}
using ClassLibrary1.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AircraftsController(IAircraftsService aircraftsService) : ControllerBase
{ 
    private readonly IAircraftsService _aircraftsService = aircraftsService;

    [HttpGet]
    public async Task <ActionResult<List<AircraftsResponse>>> GetAircrafts()
    {
        var aircraft = await _aircraftsService.GetAllAircrafts();
        
        var response = aircraft.Select(x => new AircraftsResponse(x.AircraftCode, x.Model, x.Range));
        
        return Ok(response);
    }
}
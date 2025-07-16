namespace WebApi.Contracts;

public record AircraftsRequest(
    string AircraftCode,
    string Model,
    int Range);
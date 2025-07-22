namespace WebApi.Contracts.Aircrafts;

public record AircraftsRequest(
    string AircraftCode,
    string ModelEn,
    string ModelRu,
    int Range);
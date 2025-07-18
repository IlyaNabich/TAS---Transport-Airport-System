namespace WebApi.Contracts;

public record AircraftsRequest(
    string AircraftCode,
    string ModelEn,
    string ModelRu,
    int Range);
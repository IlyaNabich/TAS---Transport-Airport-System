using NpgsqlTypes;

namespace WebApi.Contracts.Airports;

public record AirportsRequest(
    string AirportCode,
    string AirportName,
    string City,
    NpgsqlPoint Coordinates,
    string Timezone);
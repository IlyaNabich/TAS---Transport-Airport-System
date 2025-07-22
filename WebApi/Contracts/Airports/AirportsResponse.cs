using NpgsqlTypes;
 
namespace WebApi.Contracts.Airports;

public record AirportsResponse(string AirportCode, string AirportName, string City, NpgsqlPoint Coordinates, string Timezone);
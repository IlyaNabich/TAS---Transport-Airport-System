using NpgsqlTypes;

namespace Core.Models;

/// <summary>
/// Airports (internal data)
/// </summary>
public class AirportsDatum
{
    // ReSharper disable once InconsistentNaming
    private const int MAX_AIRPORT_CODE_LENGTH = 3;
    
    // ReSharper disable once InconsistentNaming
    private const int MAX_AIRPORT_NAME_LENGTH = 80;
    
    // ReSharper disable once InconsistentNaming
    private const int MAX_AIRPORT_CITY_LENGTH = 60;
    
    private AirportsDatum(string airportCode, string airportName, string city, NpgsqlPoint coordinates, string timezone)
    {
        AirportCode = airportCode;
        AirportName = airportName;
        City = city;
        Coordinates = coordinates;
        Timezone = timezone;
    }
    /// <summary>
    /// Airport code
    /// </summary>
    public string AirportCode { get; } = null!;

    /// <summary>
    /// Airport name
    /// </summary>
    public string AirportName { get; } = null!;

    /// <summary>
    /// City
    /// </summary>
    public string City { get; } = null!;

    /// <summary>
    /// Airport coordinates (longitude and latitude)
    /// </summary>
    public NpgsqlPoint Coordinates { get; }

    /// <summary>
    /// Airport time zone
    /// </summary>
    public string Timezone { get; } = null!;

    public static (AirportsDatum airportsDatum, string Error) CreateAirports(string? airportCode, string? airportName, string? city, NpgsqlPoint coordinates, string timezone)
    {
        var error = string.Empty;

        if (string.IsNullOrWhiteSpace(airportCode) || airportCode.Length > MAX_AIRPORT_CODE_LENGTH)
        {
            error = "Airport code can not be empty or more than 3 characters.";
        }

        if (string.IsNullOrWhiteSpace(airportCode) || airportCode.Any(char.IsNumber) || !airportCode.Any(char.IsUpper) || !airportCode.Any(c =>c > 127))
        {
            error = "The airport code cannot be empty or contain numbers or lower case non-English letters.";
        }
        
        if (string.IsNullOrWhiteSpace(airportName) || airportName.Any(char.IsNumber) || airportName.Length > MAX_AIRPORT_NAME_LENGTH)
        {
            error = "The airport name cannot be empty or contain numbers or more than 80 characters.";
        }

        if (string.IsNullOrWhiteSpace(city) || city.Any(char.IsNumber) || city.Length > MAX_AIRPORT_CITY_LENGTH)
        {
            error = "City cannot be empty or contain numbers or more than 60 characters.";
        }
        
        
        var airports = new AirportsDatum(airportCode, airportName, city, coordinates, timezone);
        return (airports, error);
    }
    
    public virtual ICollection<Flight> FlightArrivalAirportNavigations { get; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAirportNavigations { get; } = new List<Flight>();
}

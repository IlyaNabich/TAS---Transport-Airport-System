using NpgsqlTypes;

namespace Core.Models;

/// <summary>
/// Airports (internal data)
/// </summary>
public partial class AirportsDatum
{
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

    public virtual ICollection<Flight> FlightArrivalAirportNavigations { get; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAirportNavigations { get; } = new List<Flight>();
}

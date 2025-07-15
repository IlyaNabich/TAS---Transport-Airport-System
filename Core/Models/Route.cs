namespace Core.Models;

public partial class Route
{
    /// <summary>
    /// Flight number
    /// </summary>
    public string? FlightNo { get; }

    /// <summary>
    /// Code of airport of departure
    /// </summary>
    public string? DepartureAirport { get; }

    /// <summary>
    /// Name of airport of departure
    /// </summary>
    public string? DepartureAirportName { get; }

    /// <summary>
    /// City of departure
    /// </summary>
    public string? DepartureCity { get; }

    /// <summary>
    /// Code of airport of arrival
    /// </summary>
    public string? ArrivalAirport { get; }

    /// <summary>
    /// Name of airport of arrival
    /// </summary>
    public string? ArrivalAirportName { get; }

    /// <summary>
    /// City of arrival
    /// </summary>
    public string? ArrivalCity { get; }

    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string? AircraftCode { get; }

    /// <summary>
    /// Scheduled duration of flight
    /// </summary>
    public TimeSpan? Duration { get; }

    /// <summary>
    /// Days of week on which flights are scheduled
    /// </summary>
    public List<int>? DaysOfWeek { get; }
}

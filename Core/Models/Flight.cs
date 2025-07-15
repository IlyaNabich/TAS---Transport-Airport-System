namespace Core.Models;

/// <summary>
/// Flights
/// </summary>
public partial class Flight
{
    /// <summary>
    /// Flight ID
    /// </summary>
    public int FlightId { get; }

    /// <summary>
    /// Flight number
    /// </summary>
    public string FlightNo { get; } = null!;

    /// <summary>
    /// Scheduled departure time
    /// </summary>
    public DateTime ScheduledDeparture { get; }

    /// <summary>
    /// Scheduled arrival time
    /// </summary>
    public DateTime ScheduledArrival { get; }

    /// <summary>
    /// Airport of departure
    /// </summary>
    public string DepartureAirport { get; } = null!;

    /// <summary>
    /// Airport of arrival
    /// </summary>
    public string ArrivalAirport { get; } = null!;

    /// <summary>
    /// Flight status
    /// </summary>
    public string Status { get; } = null!;

    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; } = null!;

    /// <summary>
    /// Actual departure time
    /// </summary>
    public DateTime? ActualDeparture { get; }

    /// <summary>
    /// Actual arrival time
    /// </summary>
    public DateTime? ActualArrival { get; }

    public virtual AircraftsDatum AircraftCodeNavigation { get; } = null!;

    public virtual AirportsDatum ArrivalAirportNavigation { get; } = null!;

    public virtual AirportsDatum DepartureAirportNavigation { get; } = null!;

    public virtual ICollection<TicketFlight> TicketFlights { get; } = new List<TicketFlight>();
}

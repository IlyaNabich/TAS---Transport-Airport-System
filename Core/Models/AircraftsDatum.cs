namespace Core.Models;

/// <summary>
/// Aircrafts (internal data)
/// </summary>
public partial class AircraftsDatum
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; } = null!;

    /// <summary>
    /// Aircraft model
    /// </summary>
    public string Model { get; } = null!;

    /// <summary>
    /// Maximal flying distance, km
    /// </summary>
    public int Range { get; }

    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();

    public virtual ICollection<Seat> Seats { get; } = new List<Seat>();
}

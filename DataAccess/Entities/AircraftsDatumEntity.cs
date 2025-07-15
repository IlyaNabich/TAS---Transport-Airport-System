namespace DataAccess.Entities;

/// <summary>
/// Aircrafts (internal data)
/// </summary>
public class AircraftsDatumEntity
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Aircraft model
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// Maximal flying distance, km
    /// </summary>
    public int Range { get; set; }

    public virtual ICollection<FlightEntity> Flights { get; set; } = new List<FlightEntity>();

    public virtual ICollection<SeatEntity> Seats { get; set; } = new List<SeatEntity>();
}

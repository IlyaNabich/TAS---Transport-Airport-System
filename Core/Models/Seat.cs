namespace Core.Models;

/// <summary>
/// Seats
/// </summary>
public partial class Seat
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; } = null!;

    /// <summary>
    /// Seat number
    /// </summary>
    public string SeatNo { get; } = null!;

    /// <summary>
    /// Travel class
    /// </summary>
    public string FareConditions { get; } = null!;

    public virtual AircraftsDatum AircraftCodeNavigation { get; } = null!;
}
